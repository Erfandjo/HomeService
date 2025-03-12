using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Dapper.HomeService.ServiceCategory.Queries
{
    public static class ServiceCategoryQueries
    {
        public static string GetBySubCategoryId =
"SELECT Id,Title,ImagePath FROM Services WHERE SubCategoryId = @Id";
    }
}
