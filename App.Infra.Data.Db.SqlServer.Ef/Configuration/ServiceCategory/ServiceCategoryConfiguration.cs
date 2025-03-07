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
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 1 , Title = "سرویس عادی نظافت" , SubCategoryId = 1 , Description="\r\nتوضیحات: سرویس نظافت معمولی برای حفظ تمیزی روزمره منزل یا محل کار. شامل گردگیری، جارو کردن، تی کشیدن و نظافت سطوح می‌شود.\r\n\r\nمزایا: مناسب برای افرادی که به دنبال حفظ نظافت پایه‌ای هستند." , BasePrice = "12000000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 2 , Title = "سرویس ویژه نظافت" , SubCategoryId = 1 , Description = "توضیحات: نظافت عمیق و دقیق برای مناطقی که نیاز به توجه بیشتری دارند. شامل تمیز کردن نقاط سخت‌دسترس، نظافت مبلمان و سطوح با دقت بالا.\r\n\r\nمزایا: ایده‌آل برای مواقعی که نیاز به تمیزی بیشتر و جزئی‌نگرانه‌تر دارید.\r\n\r\n", BasePrice = "350000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 3 , Title = "سرویس لوکس نظافت" , SubCategoryId = 1 , Description = "توضیحات: سرویس نظافتی با بالاترین استانداردها و استفاده از مواد شوینده لوکس و تجهیزات پیشرفته. شامل نظافت کامل و براق‌سازی سطوح.\r\n\r\nمزایا: مناسب برای منازل و دفاتر لوکس که به دنبال بهترین کیفیت هستند." , BasePrice = "12000000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 4 , Title = "نظافت راه‌ پله" , SubCategoryId = 1 , Description = "توضیحات: سرویس اختصاصی برای تمیز کردن و براق‌سازی راه‌پله‌ها، شامل پاک‌کردن لکه‌ها و گردگیری کامل.\r\n\r\nمزایا: مناسب برای ساختمان‌های مسکونی و اداری با راه‌پله‌های زیاد." , BasePrice = "1400000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 5 , Title = "سرویس نظافت فوری" , SubCategoryId = 1 , Description = "توضیحات: سرویس سریع و بدون نیاز به وقت‌گیری قبلی برای مواقع اضطراری که نیاز به نظافت فوری دارید.\r\n\r\nمزایا: مناسب برای مهمانی‌های ناگهانی یا بازدیدهای غیرمنتظره." , BasePrice = "210000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 6 , Title = "سمپاشی فضای داخلی" , SubCategoryId = 1 , Description = "توضیحات: سرویس سمپاشی برای از بین بردن حشرات موذی در فضای داخلی منزل یا محل کار. استفاده از مواد ایمن و موثر.\r\n\r\nمزایا: ایجاد محیطی سالم و عاری از حشرات." , BasePrice = "2100000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 7 , Title = "پذیرایی" , SubCategoryId = 1 , Description = "توضیحات: ارائه نیروی کار ساده برای انجام کارهای سبک مانند جابجایی وسایل، نظافت اولیه و کمک در امور روزمره.\r\n\r\nمزایا: مناسب برای مواقعی که نیاز به کمک فوری دارید." , BasePrice = "2400000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 8 , Title = "کارگر ساده" , SubCategoryId = 1 , Description = "توضیحات: سرویس شستشوی حرفه‌ای مبلمان، موکت و فرش در محل شما، بدون نیاز به جابجایی وسایل.\r\n\r\nمزایا: صرفه‌جویی در زمان و حفظ کیفیت وسایل." , BasePrice = "2100000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 9 , Title = "(شستشو در محل (مبل، موکت، فرش)" , SubCategoryId = 2 , Description = "توضیحات: سرویس شستشوی حرفه‌ای مبلمان، موکت و فرش در محل شما، بدون نیاز به جابجایی وسایل. استفاده از دستگاه‌های پیشرفته و مواد شوینده مناسب برای هر نوع پارچه.\r\n\r\nمزایا:\r\n\r\nصرفه‌جویی در زمان و انرژی.\r\n\r\nجلوگیری از آسیب‌های ناشی از جابجایی.\r\n\r\nمناسب برای خانواده‌های شلوغ یا افرادی که وقت کافی برای نظافت ندارند." , BasePrice = "250000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 10 , Title = "قالیشویی" , SubCategoryId = 2 , Description = "توضیحات: سرویس شستشوی تخصصی فرش‌ها با دستگاه‌های مدرن و مواد شوینده مخصوص. این سرویس شامل ضدعفونی و خوشبوسازی فرش نیز می‌شود.\r\n\r\nمزایا:\r\n\r\nاز بین بردن لکه‌های سخت و عمیق.\r\n\r\nافزایش عمر فرش و حفظ رنگ آن.\r\n\r\nمناسب برای فرش‌های دست‌باف و ماشینی." , BasePrice = "241555"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 11 , Title = "خشکشویی" , SubCategoryId = 2 , Description = "توضیحات: سرویس خشکشویی حرفه‌ای برای لباس‌ها و پارچه‌های ظریف که نیاز به شستشوی خاص دارند.\r\n\r\nمزایا: مناسب برای لباس‌های گران‌قیمت و حساس." , BasePrice = "12000000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 23 , Title = "پرده‌شویی" , SubCategoryId = 2 , Description = "\r\nتوضیحات: سرویس شستشوی حرفه‌ای پرده‌ها در محل شما یا در کارگاه تخصصی. این سرویس شامل شستشو، ضدعفونی و اتوکشی پرده‌ها می‌شود.\r\n\r\nمزایا:\r\n\r\nحفظ بافت و رنگ پرده‌ها.\r\n\r\nمناسب برای پرده‌های ظریف و حساس.\r\n\r\nصرفه‌جویی در زمان و هزینه." , BasePrice = "15420000"},
                                                   
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 12 , Title = "سرامیک‌ خودرو" , SubCategoryId = 3 , Description = "توضیحات: سرویس براق‌سازی و محافظت از سرامیک خودرو برای افزایش طول عمر و زیبایی آن.\r\n\r\nمزایا: محافظت از رنگ و بدنه خودرو در برابر عوامل محیطی." , BasePrice = "1400000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 13 , Title = "کارواش نانو" , SubCategoryId = 3 ,Description =  "\r\nتوضیحات: استفاده از فناوری نانو برای شستشو و محافظت از بدنه خودرو، ایجاد لایه‌ای ضد خش و ضد آب.\r\n\r\nمزایا: افزایش درخشندگی و محافظت طولانی‌مدت." , BasePrice = "4100000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 14 , Title = "کارواش با آب" , SubCategoryId = 3 , Description = "\r\nتوضیحات: سرویس شستشوی خودرو با استفاده از آب و مواد شوینده مخصوص، برای تمیز کردن بدنه، شیشه‌ها، چرخ‌ها و سایر قسمت‌های بیرونی خودرو. این سرویس به صورت حرفه‌ای و با دقت بالا انجام می‌شود.\r\n\r\nمزایا:\r\n\r\nاز بین بردن گرد و غبار، لکه‌ها و آلودگی‌های سطحی.\r\n\r\nمناسب برای شستشوی سریع و روزمره خودرو.\r\n\r\nافزایش زیبایی ظاهری خودرو در کمترین زمان." , BasePrice = "2700000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 15 , Title = "واکس و پولیش خودرو" , SubCategoryId = 3 , Description = "\r\nتوضیحات: سرویس تخصصی واکس و پولیش خودرو برای بازگرداندن درخشش و زیبایی اولیه بدنه خودرو. این سرویس شامل پولیش برای از بین بردن خش‌های سطحی و واکس برای ایجاد لایه‌ای محافظ و براق‌کننده است.\r\n\r\nمزایا:\r\n\r\nمحافظت از رنگ و بدنه خودرو در برابر عوامل محیطی مانند نور خورشید، باران و آلودگی.\r\n\r\nاز بین بردن خش‌ها و لکه‌های سطحی.\r\n\r\nمناسب برای خودروهای قدیمی که نیاز به احیا دارند." , BasePrice ="2100000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 16 , Title = "صفرشویی خودرو" , SubCategoryId = 3 , Description = "توضیحات: سرویس نظافت کامل خودرو از داخل و خارج، شامل شستشوی موتور و زیر خودرو.\r\n\r\nمزایا: مناسب برای خودروهای نو یا خودروهایی که نیاز به نظافت کامل دارند." , BasePrice = "140000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 17 , Title = "موتورشویی خودرو" , SubCategoryId = 3 , Description = "\r\nتوضیحات: سرویس شستشوی موتور خودرو برای افزایش کارایی و زیبایی آن.\r\n\r\nمزایا: افزایش طول عمر موتور و بهبود عملکرد." , BasePrice = "1700000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 18 , Title = "پکیج کارواش VIP (صفرشویی VIP + واکس و پولیش سه مرحله‌ای)" , SubCategoryId = 3 , Description = "توضیحات: سرویس ویژه برای خودروهای لوکس، شامل صفرشویی کامل، واکس و پولیش سه مرحله‌ای.\r\n\r\nمزایا: مناسب برای خودروهای گران‌قیمت که نیاز به مراقبت ویژه دارند" , BasePrice = "1400000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 19 , Title = "شفاف‌سازی چراغ خودرو" , SubCategoryId = 3 , Description = "توضیحات: سرویس بازگرداندن شفافیت چراغ‌های خودرو که به مرور زمان کدر شده‌اند.\r\n\r\nمزایا: بهبود دید در شب و افزایش ایمنی." , BasePrice = "1000000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 20 , Title = "احیای رنگ خودرو" , SubCategoryId = 3 , Description = "\r\nتوضیحات: سرویس بازگرداندن رنگ اصلی خودرو و از بین بردن خش‌ها و لکه‌های سطحی.\r\n\r\nمزایا: افزایش زیبایی و ارزش خودرو." , BasePrice = "2700000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 21 , Title = "صافکاری و نقاشی خودرو" , SubCategoryId = 3 , Description = "توضیحات: سرویس تخصصی صافکاری و نقاشی خودرو برای رفع خراش‌ها و آسیب‌های بدنه.\r\n\r\nمزایا: بازگرداندن ظاهر اولیه خودرو." , BasePrice = "2100000"},
                new Domain.Core.HomeService.ServiceCategoryEntity.Entities.ServiceCategory() { Id = 22 , Title = "نصب شیشه دودی خودرو در محل" , SubCategoryId = 3 , Description = "\r\nتوضیحات: سرویس نصب شیشه دودی با کیفیت بالا برای افزایش حریم خصوصی و کاهش حرارت داخل خودرو.\r\n\r\nمزایا: بهبود ظاهر و راحتی خودرو." , BasePrice = "2100000"},
                

            });

        }
    }
}
