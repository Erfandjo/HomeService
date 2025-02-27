namespace App.Domain.Core.HomeService.AdminEntity.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public UserEntity.Entities.User User { get; set; }
        public int UserId { get; set; }
    }
}
