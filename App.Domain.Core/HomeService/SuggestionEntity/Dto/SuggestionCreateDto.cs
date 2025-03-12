using App.Domain.Core.HomeService.ExpertEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Entities;
using App.Domain.Core.HomeService.SuggestionEntity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.SuggestionEntity.Dto
{
    public class SuggestionCreateDto
    {
        public int Id { get; set; }
        public string SuggestedPrice { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public string? Description { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
    }
}
