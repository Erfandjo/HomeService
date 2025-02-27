using App.Domain.Core.HomeService.ImageEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Image
{
    public class ImageConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.ImageEntity.Entities.Image>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.ImageEntity.Entities.Image> builder)
        {
            builder.HasOne(x => x.Request)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.RequestId);

            builder.HasData(new List<Domain.Core.HomeService.ImageEntity.Entities.Image>()
            {
                new Domain.Core.HomeService.ImageEntity.Entities.Image() { Id = 1, RequestId = 1, Path = "Images/trending/1.jpg" },
                new Domain.Core.HomeService.ImageEntity.Entities.Image() { Id = 2, RequestId = 2, Path = "Images/trending/2.jpg" },
                new Domain.Core.HomeService.ImageEntity.Entities.Image() { Id = 3, RequestId = 2, Path = "Images/trending/4.jpg" },
                new Domain.Core.HomeService.ImageEntity.Entities.Image() { Id = 4, RequestId = 3, Path = "Images/trending/3.jpg" },
                new Domain.Core.HomeService.ImageEntity.Entities.Image() { Id = 5, RequestId = 4, Path = "Images/trending/5.jpg" },
                new Domain.Core.HomeService.ImageEntity.Entities.Image() { Id = 6, RequestId = 4, Path = "Images/trending/6.jpg" }
            });

        }
    }
}
