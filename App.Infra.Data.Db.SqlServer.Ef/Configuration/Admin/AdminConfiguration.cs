using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Admin
{
    public class AdminConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.Admin.Entities.Admin>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.Admin.Entities.Admin> builder)
        {
            builder.HasData(new List<Domain.Core.HomeService.Admin.Entities.Admin>()
            {
                new Domain.Core.HomeService.Admin.Entities.Admin()
                {
                    Id = 1,
                }
            });
        }
    }
}
