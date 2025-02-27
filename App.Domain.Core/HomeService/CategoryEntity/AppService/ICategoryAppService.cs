using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.CategoryEntity.AppService
{
    public interface ICategoryAppService
    {
        public Task<List<CategorySummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Result> Add(CategoryCreateDto category, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<CategoryUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<Result> Update(CategoryUpdateDto Category, CancellationToken cancellation);
    }
}
