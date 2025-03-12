using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Dapper.HomeService.SubCategory.Queries
{
    public class SubCategoryQueries
    {

        public static string GetByCategoryId =
    "SELECT Id,Title,ImagePath FROM SubCategories WHERE CategoryId = @Id";
    }
}
