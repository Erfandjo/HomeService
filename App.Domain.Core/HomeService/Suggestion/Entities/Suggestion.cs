using App.Domain.Core.HomeService.Suggestion.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.Suggestion.Entities
{
    public class Suggestion
    {
        #region Properties
        public int Id { get; set; }
        public float SuggestedPrice { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public string? Description { get; set; }
        public DateOnly SuggestionAt { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
        public StatusSuggestionEnum Status { get; set; }
        #endregion

        #region Properties
        public Expert.Entities.Expert Expert { get; set; }
        public Request.Entities.Request Request { get; set; }
        #endregion
    }
}
