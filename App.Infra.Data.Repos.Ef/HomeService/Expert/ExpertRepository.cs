﻿using App.Domain.Core.HomeService.ExpertEntity.Data;
using App.Domain.Core.HomeService.ResultEntity;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Expert
{
    public class ExpertRepository(AppDbContext _dbContext) : IExpertRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.ExpertEntity.Entities.Expert expert, CancellationToken cancellation)
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

        public async Task<List<Domain.Core.HomeService.ExpertEntity.Entities.Expert>>? GetAll(Domain.Core.HomeService.ExpertEntity.Entities.Expert expert, CancellationToken cancellation)
        {
            return await _dbContext.Experts.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.ExpertEntity.Entities.Expert>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Price(int id, string price, CancellationToken cancellation)
        {
           var user =  await _dbContext.Experts.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            user.User.Balance = Convert.ToString(int.Parse(user.User.Balance) + int.Parse(price));
           await _dbContext.SaveChangesAsync();
            return new Result(true, "با موفقیت انجام شد"); 
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.ExpertEntity.Entities.Expert expert, CancellationToken cancellation)
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
