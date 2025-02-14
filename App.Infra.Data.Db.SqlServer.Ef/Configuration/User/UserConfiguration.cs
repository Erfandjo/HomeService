using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.User
{
    public class UserConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.User.Entities.User>
    {

        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.User.Entities.User> builder)
        {
            builder.HasOne(x => x.City)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.CityId);

            //builder.HasOne(x => x.Admin)
            //    .WithOne(x => x.User);

            builder.HasOne(x => x.Expert)
                .WithOne(x => x.User);


            builder.HasOne(x => x.Customer)
                .WithOne(x => x.User);






            //new ApplicationUser()
            //{
            //    Id = 1,
            //    UserName = "Admin@gmail.com",
            //    NormalizedUserName = "ADMIN@GMAIL.COM",
            //    Email = "Admin@gmail.com",
            //    NormalizedEmail = "ADMIN@GMAIL.COM",
            //    LockoutEnabled = false,
            //    PhoneNumber = "09913466961",
            //    FirstName = "ادمین",
            //    LastName = "ادمین",
            //    ProfileImageUrl = "/userassets/img/1.png",
            //    SecurityStamp = Guid.NewGuid().ToString()
            //},
        }

        public static void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<Domain.Core.HomeService.User.Entities.User>();

            //SeedUsers
            var users = new List<Domain.Core.HomeService.User.Entities.User>
        {
            new Domain.Core.HomeService.User.Entities.User()
            {
                Id = 1,
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09377507920",
                SecurityStamp = Guid.NewGuid().ToString(),
                CityId = 1,
                RegisterAt = DateTime.Now,
               
            },
        };

            foreach (var user in users)
            {
                var passwordHasher = new PasswordHasher<Domain.Core.HomeService.User.Entities.User>();
                user.PasswordHash = passwordHasher.HashPassword(user, "123456");
                builder.Entity<Domain.Core.HomeService.User.Entities.User>().HasData(user);
            }

            // Seed Roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Expert", NormalizedName = "EXPERT" },
                new IdentityRole<int>() { Id = 3, Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            //Seed Role To Users
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { RoleId = 1, UserId = 1 }
            );
        }



    }
}
