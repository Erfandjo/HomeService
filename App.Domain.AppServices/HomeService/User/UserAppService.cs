using App.Domain.Core.HomeService.CustomerEntity.Entities;
using App.Domain.Core.HomeService.ExpertEntity.Entities;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SubCategoryEntity.Entities;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using App.Domain.Core.HomeService.UserEntity.Enum;
using App.Domain.Core.HomeService.UserEntity.Service;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.AppServices.HomeService.User
{
    public class UserAppService(UserManager<Core.HomeService.UserEntity.Entities.User> userManager, SignInManager<Core.HomeService.UserEntity.Entities.User> _signInManager, IUserService _userService, IImageService _imageService) : IUserAppService
    {
        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
           return await _userService.Delete(id, cancellation);
        }

        public async Task<List<UserSummaryDto>>? GetAll(CancellationToken cancellation)
        {
          return await  _userService.GetAll(cancellation);
        }

        public async Task<UserCreateDto>? GetById(int id, CancellationToken cancellation)
        {
            return await _userService.GetById(id, cancellation);
        }

        public async Task<UserUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _userService.GetByIdForUpdate(id, cancellation);
        }

        public Task<int> GetCount(CancellationToken cancellation) => _userService.GetCount(cancellation);
        

        public async Task<IdentityResult> Login(string username, string password, bool rememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, false);

            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed();
        }

        public async Task<IdentityResult> Register(UserCreateDto model , CancellationToken cancellationToken)
        {
            if(model.Password != model.RePassword)
                return IdentityResult.Failed(new IdentityError() { Description = "رمزعبور با تکرار رمزعبور مطابقت ندارد"});


            string role = string.Empty;

            var user = new Core.HomeService.UserEntity.Entities.User();

            user.UserName = model.UserName;
            user.RegisterAt = DateTime.Now;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.CityId = model.CityId;
            user.RoleId = (int) model.Role;
            user.PhoneNumber = model.PhoneNumber;
            user.Balance = model.Balance;
            

            

            if (model.Role == RoleEnum.Admin)
            {
                role = "Admin";
                user.RoleId = (int) RoleEnum.Admin;
            }

            if (model.Role == RoleEnum.Expert)
            {
                role = "Expert";
                user.RoleId = (int)RoleEnum.Expert;
                user.Expert = new Expert()
                {
                    
                };
            }

            if (model.Role == RoleEnum.Customer)
            {
                role = "Customer";
                user.RoleId = (int)RoleEnum.Customer;
                user.Customer = new Customer()
                {
                    
                };
            }

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

                if (model.ProfileImgFile is not null)
                {
                    user.ImagePath = await _imageService.UploadImage(model.ProfileImgFile!, "Profiles", cancellationToken);
                }

                await userManager.AddToRoleAsync(user, role);
               

                if (model.Role == RoleEnum.Expert)
                {
                    await userManager.AddClaimAsync(user, new Claim("ExpertId", user.Expert.Id.ToString()));
                }

                if (model.Role == RoleEnum.Customer)
                {
                    await userManager.AddClaimAsync(user, new Claim("CustomerId", user.Customer.Id.ToString()));
                }
            }

            return result;
        }

        public async Task<Result> Update(UserUpdateDto user, CancellationToken cancellation)
        {
            if (user.ProfileImgFile is not null)
            {
                user.ImagePath = await _imageService.UploadImage(user.ProfileImgFile!, "Profiles", cancellation);
            }
             
             return await _userService.Update(user, cancellation);
            
        }

        Task<Core.HomeService.UserEntity.Entities.User>? IUserAppService.GetById(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
