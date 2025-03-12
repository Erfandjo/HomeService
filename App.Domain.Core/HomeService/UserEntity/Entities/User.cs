using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.ExpertEntity.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.HomeService.UserEntity.Entities
{

    public class User : IdentityUser<int>
    {
        #region Properties
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImagePath { get; set; }
        public DateTime RegisterAt { get; set; }
        public string? Balance { get; set; } = "0";
        public bool IsDeleted { get; set; } = false;
        public int RoleId { get; set; }
        public int? CityId { get; set; }
        #endregion

        #region NavigationProperties
        public City? City { get; set; }
        public Expert? Expert { get; set; }
        public CustomerEntity.Entities.Customer? Customer { get; set; }
        // public Admin.Entities.Admin? Admin { get; set; }
        #endregion
    }
}
