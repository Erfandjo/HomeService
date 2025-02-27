using App.Domain.Core.HomeService.CategoryEntity.Data;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CategoryEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Services.HomeService.Category
{
    public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
    {
        public async Task<Result> Add(CategoryCreateDto category, CancellationToken cancellation)
        {
            return await _categoryRepository.Add(category , cancellation);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            return await (_categoryRepository.Delete(id, cancellation));
        }

        public async Task<List<CategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _categoryRepository.GetAll(cancellation);
        }

        public async Task<CategoryUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _categoryRepository.GetByIdForUpdate(id, cancellation);
        }

        public async Task<Result> Update(CategoryUpdateDto Category, CancellationToken cancellation)
        {
            return await _categoryRepository.Update(Category, cancellation);
        }
    }
}
