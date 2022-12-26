using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cure.Authentication.Models;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;
using Cure.Authentication.Data;

namespace Cure.Authentication.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ServiceConfiguration _appSettings;
        private readonly ICureRepository _cureRepository;

        private readonly TokenValidationParameters _tokenValidationParameters;
        public IdentityService(IOptions<ServiceConfiguration> settings,
            TokenValidationParameters tokenValidationParameters,
            ICureRepository cureRepository)
        {
            _appSettings = settings.Value;
            _tokenValidationParameters = tokenValidationParameters;
            _cureRepository = cureRepository;
        }


        public async Task<ResponseModel<TokenModel>> LoginAsync(LoginModel login)
        {
            ResponseModel<TokenModel> response = new ResponseModel<TokenModel>();
            try
            {
                var userList = _cureRepository.GetUsers();
                UsersMaster loginUser = userList.FirstOrDefault(c => c.UserName == login.UserName && c.Password == login.Password);

                if (loginUser == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Invalid Username And Password";
                    return response;
                }


                AuthenticationResult authenticationResult = await AuthenticateAsync(loginUser);
                if (authenticationResult != null && authenticationResult.Success)
                {
                    response.Data = new TokenModel() { Token = authenticationResult.Token, RefreshToken = authenticationResult.RefreshToken };
                }
                else
                {
                    response.Message = "Something went wrong!";
                    response.IsSuccess = false;

                }

                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<AuthenticationResult> AuthenticateAsync(UsersMaster user)
        {
            // authentication successful so generate jwt token
            AuthenticationResult authenticationResult = new AuthenticationResult();
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.JwtSettings.Secret);

                ClaimsIdentity Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName",user.LastName),
                    new Claim("EmailId",user.Email==null?"":user.Email),
                    new Claim("UserName",user.UserName==null?"":user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    });
                foreach (var item in _cureRepository.GetUserRoles(user.UserId))
                {
                    Subject.AddClaim(new Claim(ClaimTypes.Role, item.RoleName));
                }

                foreach (var item in _cureRepository.GetUserRegions(user.UserId))
                {
                    Subject.AddClaim(new Claim("region", item.RegionName));
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = Subject,
                    Expires = DateTime.UtcNow.Add(_appSettings.JwtSettings.TokenLifetime),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                authenticationResult.Token = tokenHandler.WriteToken(token);


                var refreshToken = new RefreshToken
                {
                    Token = Guid.NewGuid().ToString(),
                    JwtId = token.Id,
                    UserId = user.UserId,
                    CreationDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddMonths(6)
                };
                authenticationResult.RefreshToken = refreshToken.Token;
                authenticationResult.Success = true;
                return authenticationResult;
            }
            catch (Exception ex)
            {

                return null;
            }

        }
    }
}
