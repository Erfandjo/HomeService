using App.Domain.Core.HomeService.CommentEntity.Entities;
using App.Domain.Core.HomeService.ImageEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Enum;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Entities;
using App.Domain.Core.HomeService.SuggestionEntity.Entities;

namespace App.Domain.Core.HomeService.RequestEntity.Dto
{
    public class RequestDetailDto
    {


        #region Properties
        public int Id { get; set; }
        public DateOnly DateOfCompletion { get; set; }
        public TimeOnly TimeOfCompletion { get; set; }
        public string? Description { get; set; }
        public DateTime RequestAt { get; set; }
        public string CustomerName { get; set; }
        public StatusRequestEnum Status { get; set; }
        public string ServiceTitle { get; set; }
        public int Price { get; set; }
        public List<Image>? Images { get; set; }
        #endregion
    }

}

