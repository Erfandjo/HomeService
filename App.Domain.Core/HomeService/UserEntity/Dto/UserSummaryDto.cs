using App.Domain.Core.HomeService.UserEntity.Enum;

namespace App.Domain.Core.HomeService.UserEntity.Dto
{
    public class UserSummaryDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Username { get; set; }
        public string? ImagePath { get; set; }
        public DateTime RegisterAt { get; set; }
        public string? Balance { get; set; }
        public RoleEnum Role { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
    }
}
