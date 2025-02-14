using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.HomeService.User.AppService
{
    public interface IUserAppService
    {
        
       
        public Task<IdentityResult> Register(string username, string password, string role);
      
        public Task<IdentityResult> Login(string username, string password , bool rememberMe);
    }
}
