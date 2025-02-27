using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Dto;

namespace App.Domain.Core.HomeService.UserEntity.Service
{
    public interface IUserService
    {
        public Task<int> GetCount(CancellationToken cancellation);
        public Task<List<UserSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<UserCreateDto>? GetById(int id, CancellationToken cancellation);
        public Task<Result> Update(UserUpdateDto user, CancellationToken cancellation);
        public Task<UserUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
    }
}
