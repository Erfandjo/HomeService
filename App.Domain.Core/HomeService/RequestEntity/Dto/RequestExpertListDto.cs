using App.Domain.Core.HomeService.RequestEntity.Enum;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.RequestEntity.Dto
{
    public class RequestExpertListDto
    {
        public int Id { get; set; }
        public DateOnly DateOfCompletion { get; set; }
        public TimeOnly TimeOfCompletion { get; set; }
        public string? ServiceImagePath { get; set; }
        public StatusRequestEnum Status { get; set; }
        public string ServiceName { get; set; }
        public bool? HasExpertSuggestion { get; set; }
        public bool? IsAcceptedSuggestion { get; set; }
    }
}
