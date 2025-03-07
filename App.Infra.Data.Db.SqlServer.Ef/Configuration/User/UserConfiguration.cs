using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Claims;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.UserEntity.Entities.User>
    {

        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.UserEntity.Entities.User> builder)
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
            var hasher = new PasswordHasher<Domain.Core.HomeService.UserEntity.Entities.User>();

            //SeedUsers
            var users = new List<Domain.Core.HomeService.UserEntity.Entities.User>
        {
            new Domain.Core.HomeService.UserEntity.Entities.User()
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
                RoleId = 1,
               
            },
            new Domain.Core.HomeService.UserEntity.Entities.User()
            {
                Id = 2,
                UserName = "Ali",
                NormalizedUserName = "ALI",
                Email = "Ali@gmail.com",
                NormalizedEmail = "ALI@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09245112357",
                SecurityStamp = Guid.NewGuid().ToString(),
                CityId = 4,
                RegisterAt = DateTime.Now,
                RoleId = 2,
            },
            new Domain.Core.HomeService.UserEntity.Entities.User()
            {
                Id = 3,
                UserName = "Mohsen@gmail.com",
                NormalizedUserName = "MOHSEN@GMAIL.COM",
                Email = "Mohsen@gmail.com",
                NormalizedEmail = "MOHSEN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09106578542",
                SecurityStamp = Guid.NewGuid().ToString(),
                CityId = 2,
                RegisterAt = DateTime.Now,
                RoleId = 2,
            },
            new Domain.Core.HomeService.UserEntity.Entities.User()
            {
                Id = 4,
                UserName = "Sahar@gmail.com",
                NormalizedUserName = "SAHAR@GMAIL.COM",
                Email = "Sahar@gmail.com",
                NormalizedEmail = "SAHAR@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09304578725",
                SecurityStamp = Guid.NewGuid().ToString(),
                CityId = 1,
                RegisterAt = DateTime.Now,
                RoleId = 2,
            },
            new Domain.Core.HomeService.UserEntity.Entities.User()
            {
                Id = 5,
                UserName = "Majid@gmail.com",
                NormalizedUserName = "MAJID@GMAIL.COM",
                Email = "Majd@gmail.com",
                NormalizedEmail = "MAJID@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09206548795",
                SecurityStamp = Guid.NewGuid().ToString(),
                CityId = 1,
                RegisterAt = DateTime.Now,
                RoleId = 3,
            },
            new Domain.Core.HomeService.UserEntity.Entities.User()
            {
                Id = 6,
                UserName = "Parvane@gmail.com",
                NormalizedUserName = "PARVANE@GMAIL.COM",
                Email = "Parvane@gmail.com",
                NormalizedEmail = "PARVANE@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09632548785",
                SecurityStamp = Guid.NewGuid().ToString(),
                CityId = 1,
                RegisterAt = DateTime.Now,
                RoleId = 3,
            },
            new Domain.Core.HomeService.UserEntity.Entities.User()
            {
                Id = 7,
                UserName = "Hasan@gmail.com",
                NormalizedUserName = "HASAN@GMAIL.COM",
                Email = "Hasan@gmail.com",
                NormalizedEmail = "HASAN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09223458712",
                SecurityStamp = Guid.NewGuid().ToString(),
                CityId = 8,
                RegisterAt = DateTime.Now,
                RoleId = 3,
            },
        };

            foreach (var user in users)
            {
                var passwordHasher = new PasswordHasher<Domain.Core.HomeService.UserEntity.Entities.User>();
                user.PasswordHash = passwordHasher.HashPassword(user, "123456");
                builder.Entity<Domain.Core.HomeService.UserEntity.Entities.User>().HasData(user);
            }

            // Seed Roles
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Expert", NormalizedName = "EXPERT" },
                new IdentityRole<int>() { Id = 3, Name = "Customer", NormalizedName = "CUSTOMER" }
            );

            builder.Entity<IdentityUserClaim<int>>().HasData(
               new IdentityUserClaim<int>() { Id = 1, ClaimType = "ExpertId" , ClaimValue = "1" , UserId = 2 },
               new IdentityUserClaim<int>() { Id = 2, ClaimType = "ExpertId", ClaimValue = "2", UserId = 3 },
               new IdentityUserClaim<int>() { Id = 3, ClaimType = "ExpertId", ClaimValue = "3", UserId = 4 },
               new IdentityUserClaim<int>() { Id = 4, ClaimType = "CustomerId", ClaimValue = "1", UserId = 5 },
               new IdentityUserClaim<int>() { Id = 5, ClaimType = "CustomerId", ClaimValue = "2", UserId = 6 },
               new IdentityUserClaim<int>() { Id = 6, ClaimType = "CustomerId", ClaimValue = "3", UserId = 7 }
           );

            //Seed Role To Users
            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>() { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 2 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 3 },
                new IdentityUserRole<int>() { RoleId = 2, UserId = 4 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 5 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 6 },
                new IdentityUserRole<int>() { RoleId = 3, UserId = 7 }
            );
        }



    }
}
