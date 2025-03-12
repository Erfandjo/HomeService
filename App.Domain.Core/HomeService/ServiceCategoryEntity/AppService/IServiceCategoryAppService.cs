using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;

namespace App.Domain.Core.HomeService.ServiceCategoryEntity.AppService
{
    public interface IServiceCategoryAppService
    {
        public Task<List<ServiceCategorySummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<Result> Add(ServiceCategoryCreateDto service, CancellationToken cancellation);
        public Task<Result> Update(ServiceCategoryUpdateDto service, CancellationToken cancellation);
        public Task<ServiceCategoryUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<List<ServiceCategorySummaryDto>>? GetBySubCategoryId(int subCategoryId, CancellationToken cancellation);
        public Task<ServiceCategorySummaryDto>? GetById(int id, CancellationToken cancellation);
        public Task<List<SkilsProfileDto>>? GetSkils(CancellationToken cancellation);
    }
}
