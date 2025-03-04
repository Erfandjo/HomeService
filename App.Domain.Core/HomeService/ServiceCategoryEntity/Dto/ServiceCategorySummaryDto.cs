namespace App.Domain.Core.HomeService.ServiceCategoryEntity.Dto
{
    public class ServiceCategorySummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public string SubCategoryTitle { get; set; }
        public string BasePrice { get; set; }
        public int VisitCount { get; set; }

    }
}
