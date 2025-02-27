using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Customer
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.CustomerEntity.Entities.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.CustomerEntity.Entities.Customer> builder)
        {
            builder.HasMany(x => x.Requests)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);


            builder.HasData(new List<Domain.Core.HomeService.CustomerEntity.Entities.Customer>()
            {
                new Domain.Core.HomeService.CustomerEntity.Entities.Customer(){ Id = 1 , Address = "Pirozi" , UserId = 5},
                new Domain.Core.HomeService.CustomerEntity.Entities.Customer(){ Id = 2 , Address = "TehranPars" , UserId = 6},
                new Domain.Core.HomeService.CustomerEntity.Entities.Customer(){ Id = 3 , Address = "KianShahr" , UserId = 7},

            });

                
        }
    }
}
