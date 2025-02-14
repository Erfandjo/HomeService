using App.Domain.Core.HomeService.Result;
using App.Domain.Core.HomeService.SubCategory.Data;
using App.Domain.Core.HomeService.Suggestion.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.HomeService.SubCategory
{
    public class SubCategoryRepository(AppDbContext _dbContext) : ISubCategoryRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.SubCategory.Entities.SubCategory subCategory, CancellationToken cancellation)
        {
            if (subCategory is null)
                return new Result(false, "SubCategory Is Null");

            await _dbContext.SubCategories.AddAsync(subCategory);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var subCategory = await _dbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (subCategory is null)
                return new Result(false, "SubCategory Not Found.");

            _dbContext.SubCategories.Remove(subCategory);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<Domain.Core.HomeService.SubCategory.Entities.SubCategory>>? GetAll(Domain.Core.HomeService.SubCategory.Entities.SubCategory subCategory, CancellationToken cancellation)
        {
            return await _dbContext.SubCategories.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.SubCategory.Entities.SubCategory>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.SubCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.SubCategory.Entities.SubCategory subCategory, CancellationToken cancellation)
        {
            var sub = await _dbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (sub is null)
                return new Result(false, "SubCategory Not Found.");

            sub.Title = subCategory.Title;
            sub.Services = subCategory.Services;
            sub.ImagePath = subCategory.ImagePath;
            sub.Category = subCategory.Category;
            sub.CategoryId = subCategory.CategoryId;

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
