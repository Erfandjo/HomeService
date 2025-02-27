using App.Domain.Core.HomeService.SuggestionEntity.Data;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using App.Domain.Core.HomeService.SuggestionEntity.Service;

namespace App.Domain.Services.HomeService.Suggestion
{
    public class SuggestionService(ISuggestionRepository _suggestionRepository) : ISuggestionService
    {
        public async Task<List<SuggestionSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _suggestionRepository.GetAll(cancellation);
        }
    }
}
