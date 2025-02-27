using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.HomeService.UserEntity.AppService
{
    public interface IUserAppService
    {
        public Task<IdentityResult> Register(UserCreateDto model , CancellationToken cancellation);
        public Task<IdentityResult> Login(string username, string password, bool rememberMe);
        public Task<int> GetCount(CancellationToken cancellation);
        public Task<List<UserSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<Entities.User>? GetById(int id, CancellationToken cancellation);
        public Task<Result> Update(UserUpdateDto user, CancellationToken cancellation);
        public Task<UserUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
    }
}
