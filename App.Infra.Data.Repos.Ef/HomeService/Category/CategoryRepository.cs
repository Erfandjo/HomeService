using App.Domain.Core.HomeService.Category.Data;
using App.Domain.Core.HomeService.Result;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;


namespace App.Infra.Data.Repos.Ef.HomeService.Category
{
    public class CategoryRepository(AppDbContext _dbContext) : ICategoryRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.Category.Entities.Category category, CancellationToken cancellation)
        {
            if (category is null)
                return new Result(false, "Category Is Null");

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
                return new Result(false, "Category Not Found.");

            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<Domain.Core.HomeService.Category.Entities.Category>>? GetAll(Domain.Core.HomeService.Category.Entities.Category category, CancellationToken cancellation)
        {
            return await _dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.Category.Entities.Category>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.Category.Entities.Category category, CancellationToken cancellation)
        {
            var cat = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (cat is null)
                return new Result(false, "Category Not Found.");


            cat.Title = category.Title;
            cat.SubCategories = category.SubCategories;
            cat.ImagePath = category.ImagePath;

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
