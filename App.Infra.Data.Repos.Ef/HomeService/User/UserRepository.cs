using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Data;
using App.Domain.Core.HomeService.UserEntity.Dto;
using App.Domain.Core.HomeService.UserEntity.Enum;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.User
{
    public class UserRepository(AppDbContext _dbContext) : IUserRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.UserEntity.Entities.User user, CancellationToken cancellation)
        {
            if (user is null)
                return new Result(false, "User Is Null");

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user is null)
                return new Result(false, "User Not Found.");


            user.IsDeleted = true;
            //_dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<UserSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Users.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new UserSummaryDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Balance = x.Balance,
                City = x.City.Title,
                RegisterAt = x.RegisterAt,
                ImagePath = x.ImagePath,
                PhoneNumber = x.PhoneNumber,
                Username = x.UserName,
                Email = x.Email,
                Role = (RoleEnum) x.RoleId
            }).ToListAsync();
        }

        public async Task<UserChangePasswordDto> GetByForChangePassword(int id , CancellationToken cancellation)
        {
            return await _dbContext.Users.AsNoTracking().Select(x => new UserChangePasswordDto()
            {
                Id = x.Id,
                Password = "",
                Repassword = "",
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Domain.Core.HomeService.UserEntity.Entities.User>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _dbContext.Users.AsNoTracking().Select(x => new UserUpdateDto()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                UserName = x.UserName,
                CityId = x.CityId,
                Balance = x.Balance,
                ImagePath = x.ImagePath,
                Role = (RoleEnum)x.RoleId,
                Email = x.Email,

            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetCount(CancellationToken cancellation) => await _dbContext.Users.CountAsync();

        public async Task<Result> Update(UserUpdateDto user, CancellationToken cancellation)
        {
            var use = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (use is null)
                return new Result(false, "User Not Found.");


            use.Email = user.Email;
            use.ImagePath = user.ImagePath;
            use.PhoneNumber = user.PhoneNumber;
            use.Balance = user.Balance;
            use.FirstName = user.FirstName;
            use.LastName = user.LastName;
            use.CityId = user.CityId;
            use.RoleId = (int) user.Role;
            use.UserName = user.UserName;
            
            

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

       
    }
}
