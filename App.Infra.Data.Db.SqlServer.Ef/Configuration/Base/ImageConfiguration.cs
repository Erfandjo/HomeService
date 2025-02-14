using App.Domain.Core.HomeService.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Base
{
    public class ImageConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.Base.Entities.Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasOne(x => x.Request)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.RequestId);
        }
    }
}
