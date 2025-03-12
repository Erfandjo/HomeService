using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.SubCategoryEntity.Data
{
    public interface ISubCategoryDapperRepository
    {
        public Task<List<SubCategorySummaryDto>>? GetByCategoryId(int categoryId, CancellationToken cancellation);
    }
}
