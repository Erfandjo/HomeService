using App.Domain.Core.HomeService.ServiceCategoryEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Service
{
    public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasOne(x => x.SubCategory)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.SubCategoryId);

            builder.HasMany(x => x.Experts)
               .WithMany(x => x.Skils);



            builder.HasData(new List<ServiceCategory>()
            {
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 1 , Title = "سرویس عادی نظافت" , SubCategoryId = 1},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 2 , Title = "سرویس ویژه نظافت" , SubCategoryId = 1},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 3 , Title = "سرویس لوکس نظافت" , SubCategoryId = 1},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 4 , Title = "نظافت راه‌ پله" , SubCategoryId = 1},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 5 , Title = "سرویس نظافت فوری" , SubCategoryId = 1},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 6 , Title = "سمپاشی فضای داخلی" , SubCategoryId = 1},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 7 , Title = "پذیرایی" , SubCategoryId = 1},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 8 , Title = "کارگر ساده" , SubCategoryId = 1},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 9 , Title = "(شستشو در محل (مبل، موکت، فرش)" , SubCategoryId = 2},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 10 , Title = "قالیشویی" , SubCategoryId = 2},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 11 , Title = "خشکشویی" , SubCategoryId = 2},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 23 , Title = "پرده‌شویی" , SubCategoryId = 2},
                                                   
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 12 , Title = "سرامیک‌ خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 13 , Title = "کارواش نانو" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 14 , Title = "کارواش با آب" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 15 , Title = "واکس و پولیش خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 16 , Title = "صفرشویی خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 17 , Title = "موتورشویی خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 18 , Title = "پکیج کارواش VIP (صفرشویی VIP + واکس و پولیش سه مرحله‌ای)" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 19 , Title = "شفاف‌سازی چراغ خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 20 , Title = "احیای رنگ خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 21 , Title = "صافکاری و نقاشی خودرو" , SubCategoryId = 3},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 22 , Title = "نصب شیشه دودی خودرو در محل" , SubCategoryId = 3},
                

            });

        }
    }
}
