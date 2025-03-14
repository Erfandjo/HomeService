using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Dto;
using App.Domain.Core.HomeService.UserEntity.Entities;

namespace App.Domain.Core.HomeService.UserEntity.Service
{
    public interface IUserService
    {
        public Task<int> GetCount(CancellationToken cancellation);
        public Task<List<UserSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<User>? GetById(int id, CancellationToken cancellation);
        public Task<Result> Update(UserUpdateDto user, CancellationToken cancellation);
        public Task<UserUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<UserChangePasswordDto> GetByForChangePassword(int id , CancellationToken cancellation);
        public Task<string>? GetImagePath(int id);
        public Task<Result> Price(string price, CancellationToken cancellation);
    }
}
