using App.Domain.Core.HomeService.User.Entities;

namespace App.Domain.Core.HomeService.Admin.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public User.Entities.User User { get; set; }
        public int UserId { get; set; }
    }
}
