using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.SubCategory.Entities
{
    public class SubCategory
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
        #endregion

        #region NavigationProperties
        public Category.Entities.Category Category { get; set; }
        public List<Service.Entities.Service> Services { get; set; }

        #endregion
    }
}
