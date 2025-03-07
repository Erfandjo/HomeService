using App.Domain.Core.HomeService.SuggestionEntity.Enum;

namespace App.Domain.Core.HomeService.SuggestionEntity.Dto
{
    public class SuggestionSummaryDto
    {
        public int Id { get; set; }
        public string SuggestedPrice { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public string? Description { get; set; }
        public DateTime SuggestionAt { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
        public StatusSuggestionEnum Status { get; set; }
    }

}
