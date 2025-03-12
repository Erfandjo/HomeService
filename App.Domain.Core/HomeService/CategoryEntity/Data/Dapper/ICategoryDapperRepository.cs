using App.Domain.Core.HomeService.CategoryEntity.Dto;

namespace App.Domain.Core.HomeService.CategoryEntity.Data.Dapper
{
    public interface ICategoryDapperRepository
    {
        public Task<List<CategorySummaryDto>>? GetAll(CancellationToken cancellation);
    }
}
