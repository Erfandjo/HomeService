using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.SubCategory.Data
{
    public interface ISubCategoryRepository
    {
        public Task<Result.Result> Add(SubCategory.Entities.SubCategory  subCategory , CancellationToken cancellation);
        public Task<Result.Result> Update(int id, SubCategory.Entities.SubCategory subCategory, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<SubCategory.Entities.SubCategory>>? GetAll(SubCategory.Entities.SubCategory subCategory, CancellationToken cancellation);
        public Task<SubCategory.Entities.SubCategory>? GetById(int id, CancellationToken cancellation);
    }
}
