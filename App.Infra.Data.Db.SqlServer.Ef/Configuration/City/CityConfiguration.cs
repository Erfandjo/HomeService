using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.City
{
    public class CityConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.CityEntity.Entities.City>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.CityEntity.Entities.City> builder)
        {
            builder.HasMany(x => x.Users)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId);


            builder.HasData(new List<Domain.Core.HomeService.CityEntity.Entities.City>()
            {
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 1, Title = "تهران" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 2, Title = "مشهد" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 3, Title = "اصفهان" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 4, Title = "شیراز" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 5, Title = "تبریز" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 6, Title = "کرج" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 7, Title = "قم" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 8, Title = "اهواز" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 9, Title = "رشت" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 10, Title = "کرمانشاه" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 11, Title = "زاهدان" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 12, Title = "ارومیه" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 13, Title = "یزد" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 14, Title = "همدان" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 15, Title = "قزوین" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 16, Title = "سنندج" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 17, Title = "بندرعباس" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 18, Title = "زنجان" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 19, Title = "ساری" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 20, Title = "بوشهر" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 21, Title = "مازندران" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 22, Title = "گرگان" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 23, Title = "کرمان" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 24, Title = "خرم آباد" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 25, Title = "سمنان" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 26,Title = "دزفول" },
                new Domain.Core.HomeService.CityEntity.Entities.City() { Id = 27,Title = "آبادان" },
            });
        }
    }
}
