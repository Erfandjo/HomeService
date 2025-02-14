using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.SubCategory
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.SubCategory.Entities.SubCategory>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.SubCategory.Entities.SubCategory> builder)
        {
            builder.HasOne(x => x.Category)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.Services)
                .WithOne(x => x.SubCategory)
                .HasForeignKey(x => x.SubCategoryId);


            builder.HasData(new List<App.Domain.Core.HomeService.SubCategory.Entities.SubCategory>()
            {
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 1 , Title = "نظافت و پذیرایی" , CategoryId = 1},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 2 , Title = "شستشو" , CategoryId = 1},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 3 , Title = "کارواش و دیتیلینگ" , CategoryId = 1},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 4 , Title = "سرمایش و گرمایش" , CategoryId = 2},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 5 , Title = "تعمیرات ساختمان" , CategoryId = 2 },
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 6 , Title = "لوله کشی" , CategoryId = 2 },
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 7 , Title = "طراحی و بازسازی ساختمان" , CategoryId = 2},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 8 , Title = "برقکاری" , CategoryId = 2 },
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 9 , Title = "چوب و کابینت" , CategoryId = 2 },
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 10 , Title = "خدمات شیشه ای ساختمان" , CategoryId = 2 },
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 11 , Title = "باغبانی و فضای سبز" , CategoryId = 2},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 12 , Title = "سرمایش و گرمایش" , CategoryId = 3},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 13 , Title = "نصب و تعمیر لوازم خانگی" , CategoryId = 3},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 14 , Title = "خدمات کامپیوتری" , CategoryId = 3},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 15 , Title = "تعمیرات موبایل" , CategoryId = 3},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 16 , Title = "باربری و جابجایی" , CategoryId = 4},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 17 , Title = "خدمات و تعمیرات خودرو" , CategoryId = 5},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 18 , Title = "کارواش و دیتیلینگ" , CategoryId = 5},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 19 , Title = "زیبایی بانوان" , CategoryId = 6},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 20 , Title = "پزشکی و پرستاری" , CategoryId = 6},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 21 , Title = "حیوانات خانگی" , CategoryId = 6},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 22 , Title = "مشاوره" , CategoryId = 6},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 23 , Title = "پیرایش و زیبایی آقایان" , CategoryId = 6},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 24 , Title = "تندرستی و ورزش" , CategoryId = 6},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 25 , Title = "خدمات شرکتی" , CategoryId = 7},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 26 , Title = "تامین نیروی انسانی" , CategoryId = 7},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 27 , Title = "خیاطی و تعمیرات لباس" , CategoryId = 8},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 28 , Title = "مجالس و رویدادها" , CategoryId = 8},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 29 , Title = "آموزش" , CategoryId = 8},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 30 , Title = "همه فن حریف" , CategoryId = 8},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 31 , Title = "خدمات فوری" , CategoryId = 8},
                new Domain.Core.HomeService.SubCategory.Entities.SubCategory() { Id = 32 , Title = "کودک" , CategoryId = 8},
            });



        }
    }
}
