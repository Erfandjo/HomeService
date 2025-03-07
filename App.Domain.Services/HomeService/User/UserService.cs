using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Data;
using App.Domain.Core.HomeService.UserEntity.Dto;
using App.Domain.Core.HomeService.UserEntity.Service;

namespace App.Domain.Services.HomeService.User
{
    public class UserService(IUserRepository _userRepository) : IUserService
    {


        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            return await _userRepository.Delete(id, cancellation);
        }

        public async Task<List<UserSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _userRepository.GetAll(cancellation);
        }

        public async Task<UserChangePasswordDto> GetByForChangePassword(int id, CancellationToken cancellation)
        {
            return await _userRepository.GetByForChangePassword(id, cancellation);
        }

        public async Task<Core.HomeService.UserEntity.Entities.User>? GetById(int id, CancellationToken cancellation)
        {
            return await _userRepository.GetById(id, cancellation);
        }

        public async Task<UserUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _userRepository.GetByIdForUpdate(id, cancellation);
        }

        public async Task<int> GetCount(CancellationToken cancellation)
        {
            return await _userRepository.GetCount(cancellation);

        }

        public async Task<string> GetImagePath(int id)
        {
            return await _userRepository.GetImagePath(id);
        }

        public async Task<Result> Price(string price, CancellationToken cancellation)
        {
            return await _userRepository.Price(price, cancellation);
        }

        public async Task<Result> Update(UserUpdateDto user, CancellationToken cancellation)
        {
            return await _userRepository.Update(user, cancellation);
        }


    }
}
