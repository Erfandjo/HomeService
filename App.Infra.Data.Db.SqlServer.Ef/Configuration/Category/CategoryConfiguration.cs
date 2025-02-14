using App.Domain.Core.HomeService.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Category
{
    public class CategoryConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.Category.Entities.Category>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.Category.Entities.Category> builder)
        {
            builder.HasMany(x => x.SubCategories)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            builder.HasData(new List<App.Domain.Core.HomeService.Category.Entities.Category>()
            {
                new Domain.Core.HomeService.Category.Entities.Category() { Id = 1 , Title = "تمیزکاری" },
                new Domain.Core.HomeService.Category.Entities.Category() { Id = 2 , Title = "ساختمان" },
                new Domain.Core.HomeService.Category.Entities.Category() { Id = 3 , Title = "تعمیرات اشیا" },
                new Domain.Core.HomeService.Category.Entities.Category() { Id = 4 , Title = "اسباب کشی و حمل بار" },
                new Domain.Core.HomeService.Category.Entities.Category() { Id = 5 , Title = "خودرو" },
                new Domain.Core.HomeService.Category.Entities.Category() { Id = 6 , Title = "سلامت و زیبایی" },
                new Domain.Core.HomeService.Category.Entities.Category() { Id = 7 , Title = "سازمان ها و مجتمع ها" },
                new Domain.Core.HomeService.Category.Entities.Category() { Id = 8 , Title = "سایر" }
            });
        }
    }
}
