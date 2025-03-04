using App.Domain.Core.HomeService.CategoryEntity.Entities;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SubCategoryEntity.Data;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using App.Domain.Core.HomeService.SubCategoryEntity.Entities;
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
        public async Task<Result> Add(SubCategoryCreateDto subCategory, CancellationToken cancellation)
        {
            if (subCategory is null)
                return new Result(false, "دسته بندی یافت نشد");

            var sub = new Domain.Core.HomeService.SubCategoryEntity.Entities.SubCategory();

            sub.Title = subCategory.Title;
            sub.ImagePath = subCategory.ImagePath;
            sub.CategoryId = subCategory.CategoryId;



            await _dbContext.SubCategories.AddAsync(sub);
            await _dbContext.SaveChangesAsync(cancellation);

            return new Result(true, "با موفقیت اضافه شد");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var subCategory = await _dbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (subCategory is null)
                return new Result(false, "دسته بندی یافت نشد");

           // _dbContext.SubCategories.Remove(subCategory);
           subCategory.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            return new Result(true, "با موفقیت حدف شد");
        }

        public async Task<List<SubCategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _dbContext.SubCategories.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new SubCategorySummaryDto()
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                Title = x.Title,
                CategoryTitle = x.Category.Title
            }).ToListAsync(cancellation);
        }

        public async Task<List<SubCategorySummaryDto>>? GetByCategoryId(int categoryId, CancellationToken cancellation)
        {
            return await _dbContext.SubCategories.Where(x => x.CategoryId == categoryId).Select(x => new SubCategorySummaryDto()
            {
                ImagePath = x.ImagePath,
                Title = x.Title,
                CategoryTitle = x.Category.Title,
                Id = x.Id
            }).ToListAsync();
        }

        public async Task<SubCategorySummaryDto>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.SubCategories.AsNoTracking().Select(x => new SubCategorySummaryDto()
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                Title = x.Title,
                CategoryTitle = x.Category.Title
            }).FirstOrDefaultAsync(x => x.Id == id , cancellation);
        }

        public async Task<SubCategoryUpdateDto> GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _dbContext.SubCategories.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new SubCategoryUpdateDto()
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                Title = x.Title,
                CategoryId = x.CategoryId,
            }).FirstOrDefaultAsync(x => x.Id == id , cancellation);
        }

        public async Task<Result> Update(SubCategoryUpdateDto subCategory, CancellationToken cancellation)
        {
            var sub = await _dbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == subCategory.Id);
            if (sub is null)
                return new Result(false, "دسته بندی یافت نشد");

            sub.Title = subCategory.Title;
            sub.ImagePath = subCategory.ImagePath;
            sub.CategoryId = subCategory.CategoryId;

            await _dbContext.SaveChangesAsync(cancellation);
            return new Result(true, "با موفقیت بروزرسانی شد");
        }




    }
}
