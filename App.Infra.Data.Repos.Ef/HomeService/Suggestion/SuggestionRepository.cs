using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SuggestionEntity.Data;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.HomeService.Suggestion
{
    public class SuggestionRepository(AppDbContext _dbContext) : ISuggestionRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion suggestion, CancellationToken cancellation)
        {
            if (suggestion is null)
                return new Result(false, "Suggestion Is Null");

            await _dbContext.Suggestions.AddAsync(suggestion);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var suggestion = await _dbContext.Suggestions.FirstOrDefaultAsync(x => x.Id == id);
            if (suggestion is null)
                return new Result(false, "Suggestion Not Found.");

            _dbContext.Suggestions.Remove(suggestion);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<SuggestionSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Suggestions.AsNoTracking().Select(x => new SuggestionSummaryDto()
            {
                Id = x.Id, 
                SuggestedPrice = x.SuggestedPrice,
                DeliveryDate = x.DeliveryDate,
                Description = x.Description,
                SuggestionAt = x.SuggestionAt,
                ExpertId = x.ExpertId,
                RequestId = x.RequestId,
                Status = x.Status,
            }).ToListAsync();
        }

        public async Task<Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion>? GetById(int id , CancellationToken cancellation)
        {
            return await _dbContext.Suggestions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.SuggestionEntity.Entities.Suggestion suggestion, CancellationToken cancellation)
        {
            var sug = await _dbContext.Suggestions.FirstOrDefaultAsync(x => x.Id == id);
            if (sug is null)
                return new Result(false, "Suggestion Not Found.");

            
            sug.SuggestionAt = suggestion.SuggestionAt;
            sug.RequestId = suggestion.RequestId;
            sug.SuggestedPrice = sug.SuggestedPrice;
            sug.DeliveryDate = suggestion.DeliveryDate;
            sug.Description = suggestion.Description;

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }

}
