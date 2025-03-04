using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SubCategoryEntity.Data;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using App.Domain.Core.HomeService.SubCategoryEntity.Service;

namespace App.Domain.Services.HomeService.SubCategory
{
    public class SubCategoryService(ISubCategoryRepository _subCategoryRepository) : ISubCategoryService
    {
        public async Task<Result> Add(SubCategoryCreateDto categoryCreateDto, CancellationToken cancellation)
        {
            return await _subCategoryRepository.Add(categoryCreateDto, cancellation);
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            return await _subCategoryRepository.Delete(id, cancellation);
        }

        public async Task<List<SubCategorySummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _subCategoryRepository.GetAll(cancellation);
        }

        public async Task<List<SubCategorySummaryDto>>? GetByCategoryId(int categoryId, CancellationToken cancellation)
        {
            return await _subCategoryRepository.GetByCategoryId(categoryId, cancellation);
        }

        public async Task<SubCategorySummaryDto>? GetById(int id, CancellationToken cancellation)
        {
            return await _subCategoryRepository.GetById(id, cancellation);
        }

        public async Task<SubCategoryUpdateDto> GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _subCategoryRepository.GetByIdForUpdate(id, cancellation);
        }

        public async Task<Result> Update(SubCategoryUpdateDto subCategory, CancellationToken cancellation)
        {
            return await _subCategoryRepository.Update(subCategory, cancellation);
        }
    }
}
