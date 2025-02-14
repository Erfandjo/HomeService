using App.Domain.Core.HomeService.Admin.Entities;
using App.Domain.Core.HomeService.Result;
using App.Domain.Core.HomeService.Suggestion.Entities;
using App.Domain.Core.HomeService.User.Data;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.User
{
    public class UserRepository(AppDbContext _dbContext) : IUserRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.User.Entities.User user, CancellationToken cancellation)
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

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<Domain.Core.HomeService.User.Entities.User>>? GetAll(Domain.Core.HomeService.User.Entities.User user, CancellationToken cancellation)
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.User.Entities.User>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.User.Entities.User user, CancellationToken cancellation)
        {
            var use = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (use is null)
                return new Result(false, "User Not Found.");

            use.Email = user.Email;
            use.PasswordHash = user.PasswordHash;
            use.ImagePath = user.ImagePath;
            use.PhoneNumber = user.PhoneNumber;
            use.Balance = user.Balance;
            use.IsActive = user.IsActive;

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
