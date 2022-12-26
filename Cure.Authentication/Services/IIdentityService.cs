using Cure.Authentication.Models;
using System.Security.Claims;

namespace Cure.Authentication.Services
{
    public interface IIdentityService
    {
        Task<ResponseModel<TokenModel>> LoginAsync(LoginModel login);

    }
}
