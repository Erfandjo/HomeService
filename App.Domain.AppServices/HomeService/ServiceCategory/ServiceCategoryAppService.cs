using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Service;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace App.Domain.AppServices.HomeService.ServiceCategory
{
    public class ServiceCategoryAppService(IServiceCategoryService _serviceCategoryService, IImageService _imageService, IMemoryCache _memoryCache) : IServiceCategoryAppService
    {
        public async Task<Result> Add(ServiceCategoryCreateDto service, CancellationToken cancellation)
        {

            if (service.ImgFile is not null)
            {
                service.ImagePath = await _imageService.UploadImage(service.ImgFile, "ServiceCategory", cancellation);
            }


            return await _serviceCategoryService.Add(service, cancellation);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            return await _serviceCategoryService.Delete(id, cancellation);
        }

        public async Task<List<ServiceCategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            // return await _serviceCategoryService.GetAll(cancellation);



            List<ServiceCategorySummaryDto> serviceCategories;
            if (_memoryCache.Get("ServiceCategoryList") is not null)
            {
                serviceCategories = _memoryCache.Get<List<ServiceCategorySummaryDto>>("ServiceCategoryList");
            }
            else
            {
                serviceCategories = await _serviceCategoryService.GetAll(cancellation);
                _memoryCache.Set("ServiceCategoryList", serviceCategories, TimeSpan.FromSeconds(10));


            }
            return serviceCategories;

        }

        public async Task<ServiceCategorySummaryDto>? GetById(int id, CancellationToken cancellation)
        {
            return await _serviceCategoryService.GetById(id, cancellation);
        }

        public async Task<ServiceCategoryUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _serviceCategoryService.GetByIdForUpdate(id, cancellation);
        }

        public async Task<List<ServiceCategorySummaryDto>>? GetBySubCategoryId(int subCategoryId, CancellationToken cancellation)
        {
            return await _serviceCategoryService.GetBySubCategoryId(subCategoryId, cancellation);
        }

        public async Task<List<SkilsProfileDto>>? GetSkils(CancellationToken cancellation)
        {
            return await _serviceCategoryService.GetSkils(cancellation);
        }

        public async Task<Result> Update(ServiceCategoryUpdateDto service, CancellationToken cancellation)
        {

            if (service.ImgFile is not null)
            {
                service.ImagePath = await _imageService.UploadImage(service.ImgFile!, "ServiceCategory", cancellation);
            }

            return await _serviceCategoryService.Update(service, cancellation);
        }
    }
}
