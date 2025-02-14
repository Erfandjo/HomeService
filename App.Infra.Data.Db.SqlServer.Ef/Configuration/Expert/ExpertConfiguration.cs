using Microsoft.EntityFrameworkCore;
using App.Domain.Core.HomeService.Expert.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Expert
{
    public class ExpertConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.Expert.Entities.Expert>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.Expert.Entities.Expert> builder)
        {
            builder.HasMany(x => x.Suggestions)
                .WithOne(x => x.Expert)
                .HasForeignKey(x => x.ExpertId);

            builder.HasMany(x => x.Skils)
                .WithMany(x => x.Experts);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Expert)
                .HasForeignKey(x => x.ExpertId);


        }
    }
}
