using App.Domain.Core.HomeService.ExpertEntity.AppService;
using App.Domain.Core.HomeService.ExpertEntity.Dto;
using App.Domain.Core.HomeService.ExpertEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Service;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.AppServices.HomeService.Expert
{
    public class ExpertAppService(IExpertService _expertService , UserManager<Core.HomeService.UserEntity.Entities.User> userManager , IUserService _userService) : IExpertAppService
    {
        public async Task<IdentityResult> ChangePassword(ExpertChangePasswordDto user, CancellationToken cancellation)
        {
            if (user.Password != user.Repassword)
                return IdentityResult.Failed(new IdentityError() { Description = "رمز عبور و تکرار آن برابر نیست" });


            var u = await _userService.GetById(user.Id, cancellation);
            return await userManager.ChangePasswordAsync(u, user.CurrentPassword, user.Password);
        }

        public async Task<ExpertProfileDto> GetByIdForProfile(int id, CancellationToken cancellation)
        {
            return await _expertService.GetByIdForProfile(id, cancellation);
        }

        public async Task<ExpertUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _expertService.GetByIdForUpdate(id, cancellation);
        }

        public async Task<Result> Update(ExpertUpdateDto expert, CancellationToken cancellation)
        {
            return await _expertService.Update(expert, cancellation);
        }
    }
}
