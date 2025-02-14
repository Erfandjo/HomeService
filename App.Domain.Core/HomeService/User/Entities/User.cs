using App.Domain.Core.HomeService.Base.Entities;
using App.Domain.Core.HomeService.Expert.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.HomeService.User.Entities
{

    public class User : IdentityUser<int>
    {
        #region Properties
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImagePath { get; set; }
        public DateTime RegisterAt { get; set; }
        public float? Balance { get; set; }
        public bool IsActive { get; set; } = false;
        public int? CityId { get; set; }
        #endregion

        #region NavigationProperties
        public City? City { get; set; }
        public Expert.Entities.Expert? Expert { get; set; }
        public Customer.Entities.Customer? Customer { get; set; }
       // public Admin.Entities.Admin? Admin { get; set; }
        #endregion
    }
}
