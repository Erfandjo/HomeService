using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Expert
{
    public class ExpertConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.ExpertEntity.Entities.Expert>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.ExpertEntity.Entities.Expert> builder)
        {
            builder.HasMany(x => x.Suggestions)
                .WithOne(x => x.Expert)
                .HasForeignKey(x => x.ExpertId);

            builder.HasMany(x => x.Skils)
                .WithMany(x => x.Experts);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Expert)
                .HasForeignKey(x => x.ExpertId);

            builder.HasData(new List<Domain.Core.HomeService.ExpertEntity.Entities.Expert>()
            {
                new Domain.Core.HomeService.ExpertEntity.Entities.Expert() { Id = 1, Biography = "ارایه بهترین خدمات برای شما" , Score = 3.4f , UserId = 2 },
                new Domain.Core.HomeService.ExpertEntity.Entities.Expert() { Id = 2, Biography = "بهترین کیفیت و پایین ترین قیمت" , Score = 4.4f , UserId = 3 },
                new Domain.Core.HomeService.ExpertEntity.Entities.Expert() { Id = 3, Biography = "رضایت مشتریان خوشحالی ماست" , Score = 4.6f , UserId = 4 },

            });

        }
    }
}
