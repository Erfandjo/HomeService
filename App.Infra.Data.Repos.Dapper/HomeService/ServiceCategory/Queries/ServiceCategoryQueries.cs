using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Dapper.HomeService.ServiceCategory.Queries
{
    public static class ServiceCategoryQueries
    {
        


        public static string GetBySubCategoryId = @"
        SELECT 
            s.Id,
            sc.Title AS SubCategoryTitle,
            s.BasePrice,
            s.VisitCount,
            s.ImagePath,
            s.Title,
            s.Description
        FROM Services s
        INNER JOIN SubCategories sc ON s.SubCategoryId = sc.Id
        WHERE s.SubCategoryId = @Id";



    }
}
