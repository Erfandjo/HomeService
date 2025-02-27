using App.Domain.Core.HomeService.CategoryEntity.Data;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;


namespace App.Infra.Data.Repos.Ef.HomeService.Category
{
    public class CategoryRepository(AppDbContext _dbContext) : ICategoryRepository
    {
        public async Task<Result> Add(CategoryCreateDto category, CancellationToken cancellation)
        {
            if (category is null)
                return new Result(false, "Category Is Null");

            var model = new Domain.Core.HomeService.CategoryEntity.Entities.Category();
            model.Title = category.Title;
            model.ImagePath = category.ImagePath;

            await _dbContext.Categories.AddAsync(model);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
                return new Result(false, "Category Not Found.");

            //_dbContext.Categories.Remove(category);
            category.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<CategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Categories.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new CategorySummaryDto()
            {
                Id = x.Id,
                Title = x.Title,
                ImagePath = x.ImagePath,
            }).ToListAsync();
        }

        public async Task<CategoryUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _dbContext.Categories.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new CategoryUpdateDto()
            {
                Id = x.Id,
                Title = x.Title,
                ImagePath = x.ImagePath,
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(CategoryUpdateDto category , CancellationToken cancellation)
        {
            var cat = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (cat is null)
                return new Result(false, "Category Not Found.");


            cat.Title = category.Title;
            cat.ImagePath = category.ImagePath;

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
