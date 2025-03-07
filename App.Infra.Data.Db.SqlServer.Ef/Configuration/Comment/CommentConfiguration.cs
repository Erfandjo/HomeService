using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Comment
{
    public class CommentConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.CommentEntity.Entities.Comment>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.CommentEntity.Entities.Comment> builder)
        {
            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ExpertId)
                .OnDelete(DeleteBehavior.NoAction);
                

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.CustomerId);

            builder.HasOne(x => x.Request)
                .WithOne(x => x.Comment)
                .OnDelete(DeleteBehavior.NoAction);
            



            builder.HasData(new List<Domain.Core.HomeService.CommentEntity.Entities.Comment>()
            {
                new Domain.Core.HomeService.CommentEntity.Entities.Comment(){Id = 1 , CommentAt = DateTime.Now , CustomerId = 1 , ExpertId = 2 , Text = "عالی بود" , RequestId = 1 , Star = 5},
                new Domain.Core.HomeService.CommentEntity.Entities.Comment(){Id = 2 , CommentAt = DateTime.Now , CustomerId = 2 , ExpertId = 1 , Text = "بسیار بد اخلاق" , RequestId = 2 , Star = 2},
                new Domain.Core.HomeService.CommentEntity.Entities.Comment(){Id = 3 , CommentAt = DateTime.Now , CustomerId = 3 , ExpertId = 2 , Text = "کار بلد", RequestId = 3 , Star = 4},
                new Domain.Core.HomeService.CommentEntity.Entities.Comment(){Id = 4 , CommentAt = DateTime.Now , CustomerId = 1 , ExpertId = 3 , Text = "حیف پولی که بهت دادم" , RequestId = 4 , Star = 1},
                //new Domain.Core.HomeService.CommentEntity.Entities.Comment(){Id = 5 , CommentAt = DateTime.Now , CustomerId = 2 , ExpertId = 3 , Text = "خیلی راضی بودم", RequestId = 2},
            });
                
        }
    }
}
