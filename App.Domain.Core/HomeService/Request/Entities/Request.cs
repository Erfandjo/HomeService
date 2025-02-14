using App.Domain.Core.HomeService.Base.Entities;
using App.Domain.Core.HomeService.Request.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.Request.Entities
{
    public class Request
    {
        #region Properties
        public int Id { get; set; }
        public DateOnly DateOfCompletion { get; set; }
        public TimeOnly TimeOfCompletion { get; set; }
        public string? Description { get; set; }
        public DateOnly RequestAt { get; set; }
        public int CustomerId { get; set; }
        public StatusRequestEnum Status { get; set; }
        #endregion

        #region NavigationProperties
        public List<Image>? Images { get; set; }
        public Customer.Entities.Customer Customer { get; set; }
        public List<Suggestion.Entities.Suggestion>? Suggestions { get; set; }
        #endregion
    }
}
