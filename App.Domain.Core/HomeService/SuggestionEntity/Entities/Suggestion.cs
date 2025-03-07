using App.Domain.Core.HomeService.ExpertEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.Entities;
using App.Domain.Core.HomeService.SuggestionEntity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.SuggestionEntity.Entities
{
    public class Suggestion
    {
        #region Properties
        public int Id { get; set; }
        public string SuggestedPrice { get; set; }
        public DateOnly DeliveryDate { get; set; }
        public string? Description { get; set; }
        public DateTime SuggestionAt { get; set; }
        public int ExpertId { get; set; }
        public int RequestId { get; set; }
        public StatusSuggestionEnum Status { get; set; }
        #endregion

        #region Properties
        public Expert Expert { get; set; }
        public Request Request { get; set; }
        #endregion
    }
}
