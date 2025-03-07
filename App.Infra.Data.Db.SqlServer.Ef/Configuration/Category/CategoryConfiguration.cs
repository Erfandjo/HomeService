using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Category
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.CategoryEntity.Entities.Category>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.CategoryEntity.Entities.Category> builder)
        {
            builder.HasMany(x => x.SubCategories)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            builder.HasData(new List<Domain.Core.HomeService.CategoryEntity.Entities.Category>()
            {
                new Domain.Core.HomeService.CategoryEntity.Entities.Category() { Id = 1 , Title = "تمیزکاری" , ImagePath = "\\Images\\Category\\df97889b-19b7-4bd4-9bd6-ab24ba2df64e170186481.jpg"},
                new Domain.Core.HomeService.CategoryEntity.Entities.Category() { Id = 2 , Title = "ساختمان" , ImagePath = "\\Images\\Category\\29727be9-976b-4cdc-894d-c54519ffe8a4Sakhteman.jpg"},
                new Domain.Core.HomeService.CategoryEntity.Entities.Category() { Id = 3 , Title = "تعمیرات اشیا" , ImagePath = "\\Images\\Category\\eb660482-afd7-4ddb-8cfc-c06105e95900TamiratAshiya.jpg"},
                new Domain.Core.HomeService.CategoryEntity.Entities.Category() { Id = 4 , Title = "اسباب کشی و حمل بار" , ImagePath = "\\Images\\Category\\812cef5c-a6fa-4b90-9575-226a430b2b98AsbabKeshi.jpg"},
                new Domain.Core.HomeService.CategoryEntity.Entities.Category() { Id = 5 , Title = "خودرو" , ImagePath = "\\Images\\Category\\c6a10cce-101c-4184-a558-ee932c1f073eKhodro.jpg"},
                new Domain.Core.HomeService.CategoryEntity.Entities.Category() { Id = 6 , Title = "سلامت و زیبایی" , ImagePath = "\\Images\\Category\\50c993b5-d39b-4cfa-b0a3-184b1a127866SalamatZibaii.jpg"},
                new Domain.Core.HomeService.CategoryEntity.Entities.Category() { Id = 7 , Title = "سازمان ها و مجتمع ها" , ImagePath = "\\Images\\Category\\a77551f4-cc95-4903-a85b-0285fe347d63Sazman.jpg"},
                new Domain.Core.HomeService.CategoryEntity.Entities.Category() { Id = 8 , Title = "سایر" , ImagePath = "\\Images\\Category\\2798b1dd-de02-4490-8265-bee8ed56ad4cSayer.png"}
            });
        }
    }
}
