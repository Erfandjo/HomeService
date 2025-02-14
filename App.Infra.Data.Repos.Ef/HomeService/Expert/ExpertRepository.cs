using App.Domain.Core.HomeService.Customer.Entities;
using App.Domain.Core.HomeService.Expert.Data;
using App.Domain.Core.HomeService.Result;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Expert
{
    public class ExpertRepository(AppDbContext _dbContext) : IExpertRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.Expert.Entities.Expert expert, CancellationToken cancellation)
        {
            if (expert is null)
                return new Result(false, "Expert Is Null");

            await _dbContext.Experts.AddAsync(expert);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var expert = await _dbContext.Experts.FirstOrDefaultAsync(x => x.Id == id);
            if (expert is null)
                return new Result(false, "Expert Not Found.");

            _dbContext.Experts.Remove(expert);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<Domain.Core.HomeService.Expert.Entities.Expert>>? GetAll(Domain.Core.HomeService.Expert.Entities.Expert expert, CancellationToken cancellation)
        {
            return await _dbContext.Experts.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.Expert.Entities.Expert>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.Expert.Entities.Expert expert, CancellationToken cancellation)
        {
            var exp = await _dbContext.Experts.FirstOrDefaultAsync(x => x.Id == id);
            if (exp is null)
                return new Result(false, "Expert Not Found.");


            exp.Skils = expert.Skils;
            exp.Score = expert.Score;
            exp.Biography = expert.Biography;

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
