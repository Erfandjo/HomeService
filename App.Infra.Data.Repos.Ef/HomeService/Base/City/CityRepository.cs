using App.Domain.Core.HomeService.Base.Data;
using App.Domain.Core.HomeService.Comment.Entities;
using App.Domain.Core.HomeService.Result;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Base.City
{
    public class CityRepository(AppDbContext _dbContext) : ICityRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.Base.Entities.City city, CancellationToken cancellation)
        {
            if (city is null)
                return new Result(false, "City Is Null");

            await _dbContext.Cities.AddAsync(city);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var city = await _dbContext.Cities.FirstOrDefaultAsync(x => x.Id == id);
            if (city is null)
                return new Result(false, "City Not Found.");

            _dbContext.Cities.Remove(city);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<Domain.Core.HomeService.Base.Entities.City>>? GetAll(Domain.Core.HomeService.Base.Entities.City city, CancellationToken cancellation)
        {
            return await _dbContext.Cities.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.Base.Entities.City>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Cities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.Base.Entities.City city, CancellationToken cancellation)
        {
            var cit = await _dbContext.Cities.FirstOrDefaultAsync(x => x.Id == id);
            if (cit is null)
                return new Result(false, "City Not Found.");

            cit.Title = city.Title;
            cit.Users = city.Users;

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
