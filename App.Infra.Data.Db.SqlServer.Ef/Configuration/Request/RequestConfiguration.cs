using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Request
{
    public class RequestConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.Request.Entities.Request>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.Request.Entities.Request> builder)
        {
            builder.HasMany(x => x.Suggestions)
                .WithOne(x => x.Request)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
            ;

            builder.HasMany(x => x.Images)
                .WithOne(x => x.Request)
                .HasForeignKey(x => x.RequestId);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Requests).
               HasForeignKey(x => x.CustomerId);
        }
    }
}
