using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CategoryEntity.Entities;
using App.Domain.Core.HomeService.ImageEntity.Entities;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using App.Domain.Core.HomeService.SubCategoryEntity.Service;
using Microsoft.Extensions.Caching.Memory;

namespace App.Domain.AppServices.HomeService.SubCategory
{
    public class SubCategoryAppService(ISubCategoryService _subCategoryService, IImageService _imageService , IMemoryCache _memoryCache) : ISubCategoryAppService
    {
        public async Task<Result> Add(SubCategoryCreateDto categoryCreateDto, CancellationToken cancellation)
        {
            if (categoryCreateDto.ImgFile is not null)
            {
                categoryCreateDto.ImagePath = await _imageService.UploadImage(categoryCreateDto.ImgFile, "SubCategory", cancellation);
            }
            

            return await _subCategoryService.Add(categoryCreateDto, cancellation);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            return await _subCategoryService.Delete(id, cancellation);
        }

        public async Task<List<SubCategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            // return await _subCategoryService.GetAll(cancellation);


            List<SubCategorySummaryDto> subCategories;
            if (_memoryCache.Get("SubCategoryList") is not null)
            {
                subCategories = _memoryCache.Get<List<SubCategorySummaryDto>>("SubCategoryList");
            }
            else
            {
                subCategories = await _subCategoryService.GetAll(cancellation);
                _memoryCache.Set("SubCategoryList", subCategories, TimeSpan.FromSeconds(10));


            }
            return subCategories;

        }

        public async Task<List<SubCategorySummaryDto>>? GetByCategoryId(int categoryId, CancellationToken cancellation)
        {
            return await _subCategoryService.GetByCategoryId(categoryId, cancellation);
        }

        public async Task<SubCategorySummaryDto>? GetById(int id, CancellationToken cancellation)
        {
            return await _subCategoryService.GetById(id, cancellation);
        }

        public async Task<SubCategoryUpdateDto> GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _subCategoryService.GetByIdForUpdate(id, cancellation);
        }

        public async Task<List<SubCategoryApiDto>> GetForApi(CancellationToken cancellation)
        {
            return await _subCategoryService.GetForApi(cancellation);
        }

        public async Task<Result> Update(SubCategoryUpdateDto subCategory, CancellationToken cancellation)
        {
            if (subCategory.ImgFile is not null)
            {
                subCategory.ImagePath = await _imageService.UploadImage(subCategory.ImgFile!, "SubCategory", cancellation);
            }
            return await _subCategoryService.Update(subCategory, cancellation);
        }
    }
}
