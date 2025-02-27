using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.CategoryEntity.Entities
{
    public class Category
    {

        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public bool IsDeleted { get; set; } = false;
        #endregion

        #region NavigationProperties

        public List<SubCategoryEntity.Entities.SubCategory>? SubCategories { get; set; }

        #endregion
    }
}
