using App.Domain.Core.HomeService.UserEntity.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.HomeService.UserEntity.Dto
{
    public class UserCreateDto
    {
        #region Properties

        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Balance { get; set; }
        public int? CityId { get; set; }
        [Required]
        public RoleEnum Role { get; set; }
        public IFormFile? ProfileImgFile { get; set; }

        public string? ImagePath { get; set; }
        #endregion

    }
}
