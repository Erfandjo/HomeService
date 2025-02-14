using App.Domain.Core.HomeService.SubCategory.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.Category.Entities
{
    public class Category
    {
        
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        #endregion

        #region NavigationProperties

        public List<SubCategory.Entities.SubCategory>? SubCategories { get; set; }

        #endregion
    }
}
