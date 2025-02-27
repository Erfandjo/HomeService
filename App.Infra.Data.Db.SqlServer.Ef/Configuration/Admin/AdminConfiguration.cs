using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Admin
{
    public class AdminConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.AdminEntity.Entities.Admin>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.AdminEntity.Entities.Admin> builder)
        {
            builder.HasData(new List<Domain.Core.HomeService.AdminEntity.Entities.Admin>()
            {
                new Domain.Core.HomeService.AdminEntity.Entities.Admin()
                {
                    Id = 1,
                }
            });
        }
    }
}
