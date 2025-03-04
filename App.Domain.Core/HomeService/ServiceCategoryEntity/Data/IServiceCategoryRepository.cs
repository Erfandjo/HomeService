using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Entities;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;

namespace App.Domain.Core.HomeService.ServiceCategoryEntity.Data
{
    public interface IServiceCategoryRepository
    {
        public Task<Result> Add(ServiceCategoryCreateDto service, CancellationToken cancellation);
        public Task<Result> Update(ServiceCategoryUpdateDto service, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<ServiceCategory>? GetById(int id, CancellationToken cancellation);
        public Task<List<ServiceCategorySummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<ServiceCategoryUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<List<ServiceCategorySummaryDto>>? GetBySubCategoryId(int subCategoryId, CancellationToken cancellation);
    }
}
