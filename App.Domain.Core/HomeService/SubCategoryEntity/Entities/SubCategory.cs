﻿using App.Domain.Core.HomeService.ServiceCategoryEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.SubCategoryEntity.Entities
{
    public class SubCategory
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; } = false;
        #endregion

        #region NavigationProperties
        public CategoryEntity.Entities.Category Category { get; set; }
        public List<ServiceCategory>? Services { get; set; }

        #endregion
    }
}
