using App.Domain.Core.HomeService.CommentEntity.Entities;
using App.Domain.Core.HomeService.ExpertEntity.Entities;
using App.Domain.Core.HomeService.ImageEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Enum;
using App.Domain.Core.HomeService.ServiceCategoryEntity.Entities;
using App.Domain.Core.HomeService.SuggestionEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.RequestEntity.Entities
{
    public class Request
    {
        #region Properties
        public int Id { get; set; }
        public DateOnly DateOfCompletion { get; set; }
        public TimeOnly TimeOfCompletion { get; set; }
        public string? Description { get; set; }
        public DateTime RequestAt { get; set; }
        public int CustomerId { get; set; }
        public StatusRequestEnum Status { get; set; }
        public int ServiceId { get; set; }
        public int Price { get; set; }
        public int? AcceptedExpertId { get; set; }
        #endregion

        #region NavigationProperties
        public List<Image>? Images { get; set; }
        public CustomerEntity.Entities.Customer Customer { get; set; }
        public List<Suggestion>? Suggestions { get; set; }
        public ServiceCategory Service { get; set; }
        public Comment? Comment { get; set; }
        public Expert? AcceptedExpert { get; set; }
        #endregion
    }
}
