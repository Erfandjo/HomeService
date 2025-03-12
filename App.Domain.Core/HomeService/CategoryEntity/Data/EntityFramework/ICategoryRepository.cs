using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.CategoryEntity.Data.EntityFramework
{
    public interface ICategoryRepository
    {
        public Task<Result> Add(CategoryCreateDto category, CancellationToken cancellation);
        public Task<Result> Update(CategoryUpdateDto Category, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<CategorySummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<CategoryUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
    }
}
