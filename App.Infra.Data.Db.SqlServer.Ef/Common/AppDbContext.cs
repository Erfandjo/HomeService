﻿using App.Domain.Core.HomeService.Admin.Entities;
using App.Domain.Core.HomeService.Base.Entities;
using App.Domain.Core.HomeService.Category.Entities;
using App.Domain.Core.HomeService.Comment.Entities;
using App.Domain.Core.HomeService.Customer.Entities;
using App.Domain.Core.HomeService.Expert.Entities;
using App.Domain.Core.HomeService.Request.Entities;
using App.Domain.Core.HomeService.Service.Entities;
using App.Domain.Core.HomeService.SubCategory.Entities;
using App.Domain.Core.HomeService.Suggestion.Entities;
using App.Domain.Core.HomeService.User.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Base;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Category;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Comment;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Customer;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Expert;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Request;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Service;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.SubCategory;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.Suggestion;
using App.Infra.Data.Db.SqlServer.Ef.Configuration.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Db.SqlServer.Ef.Common
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ExpertConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SuggestionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());


            UserConfiguration.SeedUsers(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }


       
        public DbSet<City> Cities { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expert> Experts { get; set; }
        //public DbSet<Admin> Admins { get; set; }

    }
}
