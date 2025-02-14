using App.Domain.Core.HomeService.Expert.Entities;

namespace App.Domain.Core.HomeService.Service.Entities
{
    public class Service
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public int SubCategoryId { get; set; }
        public int? VisitCount { get; set; }
        public float BasePrice { get; set; }
        
        #endregion

        #region NavigationProperties
        public SubCategory.Entities.SubCategory SubCategory { get; set; }
        public List<Expert.Entities.Expert> Experts { get; set; }
        #endregion
    }
}
