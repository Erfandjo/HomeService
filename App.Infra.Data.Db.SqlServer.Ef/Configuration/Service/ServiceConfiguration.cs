using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Service
{
    public class ServiceConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.Service.Entities.Service>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.Service.Entities.Service> builder)
        {
            builder.HasOne(x => x.SubCategory)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.SubCategoryId);

            builder.HasMany(x => x.Experts)
               .WithMany(x => x.Skils);



            builder.HasData(new List<App.Domain.Core.HomeService.Service.Entities.Service>()
            {
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 1 , Title = "سرویس عادی نظافت" , SubCategoryId = 1},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 2 , Title = "سرویس ویژه نظافت" , SubCategoryId = 1},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 3 , Title = "سرویس لوکس نظافت" , SubCategoryId = 1},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 4 , Title = "نظافت راه‌ پله" , SubCategoryId = 1},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 5 , Title = "سرویس نظافت فوری" , SubCategoryId = 1},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 6 , Title = "سمپاشی فضای داخلی" , SubCategoryId = 1},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 7 , Title = "پذیرایی" , SubCategoryId = 1},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 8 , Title = "کارگر ساده" , SubCategoryId = 1},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 9 , Title = "(شستشو در محل (مبل، موکت، فرش)" , SubCategoryId = 2},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 10 , Title = "قالیشویی" , SubCategoryId = 2},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 11 , Title = "خشکشویی" , SubCategoryId = 2},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 23 , Title = "پرده‌شویی" , SubCategoryId = 2},

                new Domain.Core.HomeService.Service.Entities.Service() { Id = 12 , Title = "سرامیک‌ خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 13 , Title = "کارواش نانو" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 14 , Title = "کارواش با آب" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 15 , Title = "واکس و پولیش خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 16 , Title = "صفرشویی خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 17 , Title = "موتورشویی خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 18 , Title = "پکیج کارواش VIP (صفرشویی VIP + واکس و پولیش سه مرحله‌ای)" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 19 , Title = "شفاف‌سازی چراغ خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 20 , Title = "احیای رنگ خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 21 , Title = "صافکاری و نقاشی خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.Service.Entities.Service() { Id = 22 , Title = "نصب شیشه دودی خودرو در محل" , SubCategoryId = 3},
                

            });

        }
    }
}
