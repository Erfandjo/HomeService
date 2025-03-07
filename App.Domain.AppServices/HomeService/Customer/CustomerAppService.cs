using App.Domain.Core.HomeService.CustomerEntity.AppService;
using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.CustomerEntity.Service;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Entities;
using App.Domain.Core.HomeService.UserEntity.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;

namespace App.Domain.AppServices.HomeService.Customer
{
    public class CustomerAppService(ICustomerService _customerService, IImageService _imageService , UserManager<Core.HomeService.UserEntity.Entities.User> userManager , IUserService _userService) : ICustomerAppService
    {
        public async Task<IdentityResult> ChangePassword(CustomerChangePasswordDto user, CancellationToken cancellation)
        {
            if (user.Password != user.Repassword)
                return IdentityResult.Failed(new IdentityError() { Description = "رمز عبور و تکرار آن برابر نیست" });


            var u = await _userService.GetById(user.Id, cancellation);
           return await userManager.ChangePasswordAsync(u, user.CurrentPassword, user.Password);
            
        }

        public async Task<string> GetBalance(int customerId, CancellationToken cancellation)
        {
            return await _customerService.GetBalance(customerId, cancellation);
        }

        public async Task<CustomerUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _customerService.GetByIdForUpdate(id, cancellation);
        }

        public async Task<Result> Paid(int customerId, string price, CancellationToken cancellation)
        {
            return await _customerService.Paid(customerId, price, cancellation);
        }

        public async Task<Result> Update(CustomerUpdateDto customer, CancellationToken cancellation)
        {
            if (customer.ProfileImgFile is not null)
            {
                customer.ImagePath = await _imageService.UploadImage(customer.ProfileImgFile!, "Profiles", cancellation);
            }
            return await _customerService.Update(customer, cancellation);
        }
    }
}
