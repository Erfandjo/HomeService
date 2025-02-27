using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Request
{
    public class RequestConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.RequestEntity.Entities.Request>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.RequestEntity.Entities.Request> builder)
        {
            builder.HasMany(x => x.Suggestions)
                .WithOne(x => x.Request)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
            

            builder.HasMany(x => x.Images)
                .WithOne(x => x.Request)
                .HasForeignKey(x => x.RequestId);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Requests).
               HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Service)
                .WithMany(x => x.Requests)
                .HasForeignKey(x => x.ServiceId);


            builder.HasData(new List<Domain.Core.HomeService.RequestEntity.Entities.Request>
            {
                new Domain.Core.HomeService.RequestEntity.Entities.Request(){ Id = 1, Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.ExpertSelection , CustomerId = 1 , Description = "Bana" , DateOfCompletion = new DateOnly(2025 , 05 , 03) ,  RequestAt = DateTime.Now , TimeOfCompletion = new TimeOnly(12 , 05) , ServiceId = 5 , Price = 240},
                new Domain.Core.HomeService.RequestEntity.Entities.Request(){ Id = 2, Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.WaitingPayment , CustomerId = 2 , Description = "Bana" , DateOfCompletion = new DateOnly(2025 , 04 , 08) ,  RequestAt = DateTime.Now , TimeOfCompletion = new TimeOnly(12 , 05) , ServiceId = 3, Price = 342},
                new Domain.Core.HomeService.RequestEntity.Entities.Request(){ Id = 3, Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.Started , CustomerId = 2 , Description = "Bana" , DateOfCompletion = new DateOnly(2025 , 08 , 18) ,  RequestAt = DateTime.Now , TimeOfCompletion = new TimeOnly(12 , 05) , ServiceId = 1, Price = 350},
                new Domain.Core.HomeService.RequestEntity.Entities.Request(){ Id = 4, Status = Domain.Core.HomeService.RequestEntity.Enum.StatusRequestEnum.WaitingExpertSelection , CustomerId = 3 , Description = "Bana" , DateOfCompletion = new DateOnly(2025 , 04 , 02) ,  RequestAt = DateTime.Now , TimeOfCompletion = new TimeOnly(12 , 05) , ServiceId = 2, Price = 840},

            });
        }
    }
}
