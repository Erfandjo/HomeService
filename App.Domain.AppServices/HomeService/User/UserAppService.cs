using App.Domain.Core.HomeService.Customer.Entities;
using App.Domain.Core.HomeService.Expert.Entities;
using App.Domain.Core.HomeService.User.AppService;
using App.Domain.Core.HomeService.User.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.HomeService.User
{
    public class UserAppService(UserManager<Core.HomeService.User.Entities.User> _userManager , SignInManager<Core.HomeService.User.Entities.User> _signInManager) : IUserAppService
    {
        public async Task<IdentityResult> Login(string username, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, false);

            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<IdentityResult> Register(string username , string password, string role)
        {


            var user = new Core.HomeService.User.Entities.User();

            user.UserName = username;
            user.RegisterAt = DateTime.Now;
            

            if (role == RoleEnum.Admin.ToString())
            {
                role = "Admin";
            }

            if (role == RoleEnum.Expert.ToString())
            {
                role = "Expert";
                user.Expert = new Expert()
                {
                    
                };
            }

            if (role == RoleEnum.Customer.ToString())
            {
                role = "Customer";
                user.Customer = new Customer()
                {
                    
                };
            }

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
               

                await _userManager.AddToRoleAsync(user, role);


                if (role == RoleEnum.Expert.ToString())
                {
                    await _userManager.AddClaimAsync(user, new Claim("ExpertId", user.Expert.Id.ToString()));
                }

                if (role == RoleEnum.Customer.ToString())
                {
                    await _userManager.AddClaimAsync(user, new Claim("CustomerId", user.Customer.Id.ToString()));
                }
            }

            return result;
        }
    }
}
