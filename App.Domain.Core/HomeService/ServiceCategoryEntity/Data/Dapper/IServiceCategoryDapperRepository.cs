using App.Domain.Core.HomeService.ServiceCategoryEntity.Dto;

namespace App.Domain.Core.HomeService.ServiceCategoryEntity.Data.Dapper
{
    public interface IServiceCategoryDapperRepository
    {
        public Task<List<ServiceCategorySummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<List<ServiceCategorySummaryDto>>? GetBySubCategoryId(int subCategoryId, CancellationToken cancellation);
    }
}
