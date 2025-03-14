using App.Domain.Core.HomeService.CommentEntity.Dto;
using App.Domain.Core.HomeService.CustomerEntity.Entities;
using App.Domain.Core.HomeService.ExpertEntity.Data;
using App.Domain.Core.HomeService.ExpertEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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

        public async Task<Result> ChangeScore(int expertId, int Score, CancellationToken cancellation)
        {
            var expert = await _dbContext.Experts.FirstOrDefaultAsync(x => x.Id == expertId);
            if (expert is null)
                return new Result(false, "کارشناس یافت نشد");


            expert.Score = (expert.Score + Score) / 2;


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

        public async Task<ExpertProfileDto> GetByIdForProfile(int id, CancellationToken cancellation)
        {
            return await _dbContext.Experts.AsNoTracking().Select(x => new ExpertProfileDto()
            {
                Id = x.Id,
                ImagePath = x.User.ImagePath,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                Comments = (List<CommentProfileDto>) x.Comments.Select(x => new Domain.Core.HomeService.CommentEntity.Dto.CommentProfileDto()
                {
                    FullName = x.Customer.User.FirstName + " " + x.Customer.User.LastName,
                    Star = x.Star,
                    Text = x.Text,
                    ServiceName = x.Request.Service.Title
                }),
                Biography = x.Biography,
                Score = x.Score,
                Skils = (List<SkilsProfileDto>) x.Skils.Select(x => new Domain.Core.HomeService.ServiceCategoryEntity.Dto.SkilsProfileDto()
                {
                    Title = x.Title,
                    
                })
            }).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<ExpertUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _dbContext.Experts.AsNoTracking().Select(x => new ExpertUpdateDto()
            {
                Id = x.Id,
                Biography = x.Biography,
                CityId = x.User.CityId,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                PhoneNumber = x.User.PhoneNumber,
                UserName = x.User.UserName,
                Balance = x.User.Balance,
                ImagePath = x.User.ImagePath,
                Email = x.User.Email,
                Skils = x.Skils.Select(x => x.Id).ToList()


            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<int>>? GetExpertSkils(int expertId, CancellationToken cancellation)
        {
            var expertSkils = await _dbContext.Experts.Where(e => e.Id == expertId)
                .SelectMany(e => e.Skils)
                .Select(c => c.Id).ToListAsync(cancellation);

            return (List<int>) expertSkils;
        }

        public async Task<Result> Price(int id, string price, CancellationToken cancellation)
        {
           var user =  await _dbContext.Experts.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
            user.User.Balance = Convert.ToString(float.Parse(user.User.Balance) + float.Parse(price));
           
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

        public async Task<Result> Update(ExpertUpdateDto expert, CancellationToken cancellation)
        {
            var exp = await _dbContext.Experts.Include(x => x.User).Include(x => x.Skils).FirstOrDefaultAsync(x => x.Id == expert.Id);
            if (exp is null)
                return new Result(false, "کارشناس پیدا نشد");


           
            var newSkillIds = expert.Skils ?? new List<int>();
            var currentSkillIds = exp.Skils.Select(s => s.Id).ToList();

          
            var skillsToRemove = exp.Skils.Where(s => !newSkillIds.Contains(s.Id)).ToList();
            foreach (var skill in skillsToRemove)
            {
                exp.Skils.Remove(skill);
            }

        
            var skillsToAdd = newSkillIds.Except(currentSkillIds).ToList();
            foreach (var skillId in skillsToAdd)
            {
                var category = await _dbContext.Services.FirstOrDefaultAsync(c => c.Id == skillId);
                if (category != null)
                {
                    exp.Skils.Add(category);
                }
            }







            exp.Biography = expert.Biography;
            exp.User.UserName = expert.UserName;
            exp.User.Email = expert.Email;
            exp.User.Balance = expert.Balance;
            exp.User.FirstName = expert.FirstName;
            exp.User.LastName = expert.LastName;
            exp.User.PhoneNumber = expert.PhoneNumber;
            exp.User.CityId = expert.CityId;
            exp.User.NormalizedEmail = expert.Email.ToUpper();
            exp.User.NormalizedUserName = expert.UserName.ToUpper();

            exp.User.ImagePath = expert.ImagePath;

            await _dbContext.SaveChangesAsync(cancellation);

            return new Result(true, "با موفقیت ویرایش شد");
        }
    }
}
