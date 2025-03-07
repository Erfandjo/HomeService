using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Data;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Service
{
    public class ServiceCategoryRepository(AppDbContext _dbContext) : IServiceCategoryRepository
    {
        public async Task<Result> Add(ServiceCategoryCreateDto service, CancellationToken cancellation)
        {
            if (service is null)
                return new Result(false, "سرویس یافت نشد");


            var categoryService = new ServiceCategory();
            categoryService.Title = service.Title;
            categoryService.SubCategoryId = service.SubCategoryId;
            categoryService.ImagePath = service.ImagePath;
            categoryService.BasePrice = service.BasePrice;
            categoryService.Description = service.Description;

            await _dbContext.Services.AddAsync(categoryService);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "سرویس با موفقیت اضافه شد");
        }


        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var service = await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service is null)
                return new Result(false, "سرویس یافت نشد");

            service.IsDeleted = true;

           // _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "سرویس با موفقیت حذف شد");
        }

        public async Task<List<ServiceCategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Services.AsNoTracking().Where(x => x.IsDeleted == false).Select(x => new ServiceCategorySummaryDto()
            {
                Id = x.Id,
                Title = x.Title,
                ImagePath = x.ImagePath,
                SubCategoryTitle = x.SubCategory.Title,
                VisitCount = x.VisitCount,
                BasePrice = x.BasePrice,
                Description = x.Description

            }).ToListAsync();
        }

        public async Task<ServiceCategorySummaryDto>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Services.AsNoTracking().Select(x => new ServiceCategorySummaryDto()
            {
                Id = x.Id,
                Title = x.Title,
                ImagePath = x.ImagePath,
                SubCategoryTitle = x.SubCategory.Title,
                VisitCount = x.VisitCount,
                BasePrice = x.BasePrice,
                Description = x.Description

            }).FirstOrDefaultAsync(x => x.Id == id , cancellation);
        }

        public async Task<ServiceCategoryUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _dbContext.Services.AsNoTracking().Select(x => new ServiceCategoryUpdateDto()
            {
                Id = x.Id,
                Title = x.Title,
                ImagePath = x.ImagePath,
                BasePrice = x.BasePrice,
                SubCategoryId = x.SubCategoryId,
                Description = x.Description
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ServiceCategorySummaryDto>>? GetBySubCategoryId(int subCategoryId, CancellationToken cancellation)
        {
            return await _dbContext.Services.AsNoTracking().Where(x => x.SubCategoryId == subCategoryId).Select(x => new ServiceCategorySummaryDto()
            {
                Id = x.Id,
                SubCategoryTitle = x.SubCategory.Title,
                BasePrice = x.BasePrice,
                VisitCount = x.VisitCount,
                ImagePath = x.ImagePath,
                Title = x.Title,
                Description = x.Description

            }).ToListAsync();
        }

        public async Task<Result> Update(ServiceCategoryUpdateDto service, CancellationToken cancellation)
        {
            var ser = await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == service.Id);
            if (ser is null)
                return new Result(false, "سرویس یافت نشد");

            ser.Title = service.Title;
            ser.BasePrice = service.BasePrice;
            ser.ImagePath = service.ImagePath;
            ser.SubCategoryId = service.SubCategoryId;
            ser.Description = service.Description;
            
            await _dbContext.SaveChangesAsync();

            return new Result(true, "سرویس با موفقیت بروزرسانی شد");
        }
    }
}
