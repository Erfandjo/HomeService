using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Comment
{
    public class CommentConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.Comment.Entities.Comment>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.Comment.Entities.Comment> builder)
        {
            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ExpertId);
                
        }
    }
}
