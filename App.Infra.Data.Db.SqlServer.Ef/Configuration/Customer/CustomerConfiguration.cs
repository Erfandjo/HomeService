using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Customer
{
    public class CustomerConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.Customer.Entities.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.Customer.Entities.Customer> builder)
        {
            builder.HasMany(x => x.Requests)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);


                
        }
    }
}
