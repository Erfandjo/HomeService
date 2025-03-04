using App.Domain.Core.HomeService.ExpertEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Entities;
using App.Domain.Core.HomeService.SubCategoryEntity.Entities;

namespace App.Domain.Core.HomeService.ServiceCategoryEntity.Entities
{
    public class ServiceCategory
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public int SubCategoryId { get; set; }
        public int VisitCount { get; set; }
        public float BasePrice { get; set; }
        public bool IsDeleted { get; set; } = false;
        

        #endregion

        #region NavigationProperties
        public SubCategory SubCategory { get; set; }
        public List<Expert>? Experts { get; set; }
        public List<Request>? Requests { get; set; }
        #endregion
    }
}
