using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cure.Authentication.Models;
using Cure.Authentication.Services;
using Microsoft.AspNetCore.Authorization;

namespace Cure.Authentication.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [Route("login")]
        [HttpPost]

        public async Task<IActionResult> LoginAsync([FromBody] LoginModel loginModel)
        {
            var result = await _identityService.LoginAsync(loginModel);
            return Ok(result);
        }

     

    }
}
