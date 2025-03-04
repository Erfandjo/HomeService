using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;

namespace App.Domain.Core.HomeService.SubCategoryEntity.Service
{
    public interface ISubCategoryService
    {
        public Task<List<SubCategorySummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<Result> Add(SubCategoryCreateDto categoryCreateDto, CancellationToken cancellation);
        public Task<SubCategoryUpdateDto> GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<Result> Update(SubCategoryUpdateDto subCategory, CancellationToken cancellation);
        public Task<SubCategorySummaryDto>? GetById(int id, CancellationToken cancellation);
        public Task<List<SubCategorySummaryDto>>? GetByCategoryId(int categoryId , CancellationToken cancellation);
    }
}
