using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.ImageEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.ServiceCategoryEntity.AppService;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Service;

namespace App.Domain.AppServices.HomeService.ServiceCategory
{
    public class ServiceCategoryAppService(IServiceCategoryService _serviceCategoryService, IImageService _imageService) : IServiceCategoryAppService
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
            return await _serviceCategoryService.GetAll(cancellation);
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
