using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.Endpoints.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserAppService _userAppService) : ControllerBase
    {



        [HttpPost("[action]")]
        public Task<IdentityResult> Register( [FromBody] UserCreateDto user, CancellationToken cancellation)
        {
            var result = _userAppService.Register(user, cancellation);
            return result;
        }


    }
}
