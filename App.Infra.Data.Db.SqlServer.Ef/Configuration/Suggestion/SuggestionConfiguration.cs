using App.Domain.Core.HomeService.Expert.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Suggestion
{
    public class SuggestionConfiguration : IEntityTypeConfiguration<App.Domain.Core.HomeService.Suggestion.Entities.Suggestion>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.Suggestion.Entities.Suggestion> builder)
        {
            builder.HasOne(x => x.Request)
                .WithMany(x => x.Suggestions)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
                

            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Suggestions)
                .HasForeignKey(x => x.ExpertId);
        }
    }
}
