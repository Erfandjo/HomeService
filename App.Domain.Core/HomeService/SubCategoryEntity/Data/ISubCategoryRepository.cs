using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using App.Domain.Core.HomeService.SubCategoryEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.SubCategoryEntity.Data
{
    public interface ISubCategoryRepository
    {
        public Task<Result> Add(SubCategoryCreateDto categoryCreateDto, CancellationToken cancellation);
        public Task<Result> Update(SubCategoryUpdateDto subCategory, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<SubCategorySummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<SubCategorySummaryDto>? GetById(int id, CancellationToken cancellation);
        public Task<SubCategoryUpdateDto> GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<List<SubCategorySummaryDto>>? GetByCategoryId(int categoryId , CancellationToken cancellation);
        public Task<List<SubCategoryApiDto>> GetForApi(CancellationToken cancellation);
    }
}
