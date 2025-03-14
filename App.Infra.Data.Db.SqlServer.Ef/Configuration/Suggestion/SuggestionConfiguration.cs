
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Configuration.Suggestion
{
    public class SuggestionConfiguration : IEntityTypeConfiguration<Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion>
    {
        public void Configure(EntityTypeBuilder<Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion> builder)
        {
            builder.HasOne(x => x.Request)
                .WithMany(x => x.Suggestions)
                .HasForeignKey(x => x.RequestId)
                .OnDelete(DeleteBehavior.NoAction);
                

            builder.HasOne(x => x.Expert)
                .WithMany(x => x.Suggestions)
                .HasForeignKey(x => x.ExpertId);



            builder.HasData(new List<Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion>()
            {
                new Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion(){Id = 1 ,ExpertId = 1 , Description = "کار شما تخصص ماست" , RequestId = 1 , SuggestionAt = DateTime.Now , DeliveryDate = new DateOnly(2025 , 05 , 02) , SuggestedPrice = "250" , Status = Domain.Core.HomeService.SuggestionEntity.Enum.StatusSuggestionEnum.NotSelection},
                new Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion(){Id = 2 ,ExpertId = 2 , Description = "کار شما تخصص ماست" , RequestId = 1 , SuggestionAt = DateTime.Now , DeliveryDate = new DateOnly(2025 , 05 , 02) , SuggestedPrice = "250" , Status = Domain.Core.HomeService.SuggestionEntity.Enum.StatusSuggestionEnum.NotSelection},
                new Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion(){Id = 3 ,ExpertId = 3 , Description = "کار شما تخصص ماست" , RequestId = 2 , SuggestionAt = DateTime.Now , DeliveryDate = new DateOnly(2025 , 05 , 02) , SuggestedPrice = "250" , Status = Domain.Core.HomeService.SuggestionEntity.Enum.StatusSuggestionEnum.NotSelection},
                new Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion(){Id = 4 ,ExpertId = 2 , Description = "کار شما تخصص ماست" , RequestId = 3 , SuggestionAt = DateTime.Now , DeliveryDate = new DateOnly(2025 , 05 , 02) , SuggestedPrice = "250" , Status = Domain.Core.HomeService.SuggestionEntity.Enum.StatusSuggestionEnum.NotSelection},
                new Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion(){Id = 5 ,ExpertId = 3 , Description = "کار شما تخصص ماست" , RequestId = 4 , SuggestionAt = DateTime.Now , DeliveryDate = new DateOnly(2025 , 05 , 02) , SuggestedPrice = "250" , Status = Domain.Core.HomeService.SuggestionEntity.Enum.StatusSuggestionEnum.NotSelection},
                     new Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion(){Id = 6 ,ExpertId = 3 , Description = "کار شما تخصص ماست" , RequestId = 4 , SuggestionAt = DateTime.Now , DeliveryDate = new DateOnly(2025 , 05 , 02) , SuggestedPrice = "250" , Status = Domain.Core.HomeService.SuggestionEntity.Enum.StatusSuggestionEnum.NotSelection},
                          new Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion(){Id =7 ,ExpertId = 3 , Description = "کار شما تخصص ماست" , RequestId = 4 , SuggestionAt = DateTime.Now , DeliveryDate = new DateOnly(2025 , 05 , 02) , SuggestedPrice = "250" , Status = Domain.Core.HomeService.SuggestionEntity.Enum.StatusSuggestionEnum.NotSelection},
                               new Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion(){Id = 8 ,ExpertId = 3 , Description = "کار شما تخصص ماست" , RequestId = 4 , SuggestionAt = DateTime.Now , DeliveryDate = new DateOnly(2025 , 05 , 02) , SuggestedPrice = "250" , Status = Domain.Core.HomeService.SuggestionEntity.Enum.StatusSuggestionEnum.NotSelection},


            });



        }
    }
}
