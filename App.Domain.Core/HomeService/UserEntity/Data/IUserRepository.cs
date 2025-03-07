using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Dto;
using App.Domain.Core.HomeService.UserEntity.Entities;

namespace App.Domain.Core.HomeService.UserEntity.Data
{
    public interface IUserRepository
    {
        public Task<Result> Add(Entities.User user, CancellationToken cancellation);
        public Task<Result> Update(UserUpdateDto user, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<UserSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<User>? GetById(int id, CancellationToken cancellation);
        public Task<int> GetCount(CancellationToken cancellation);
        public Task<UserUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<UserChangePasswordDto> GetByForChangePassword(int id, CancellationToken cancellation);
        public Task<string> GetImagePath(int id);
    }
}
