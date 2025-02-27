using App.Domain.Core.HomeService.SuggestionEntity.AppService;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using App.Domain.Core.HomeService.SuggestionEntity.Service;

namespace App.Domain.AppServices.HomeService.Suggestion
{
    public class SuggestionAppService(ISuggestionService _suggestionService) : ISuggestionAppService
    {
        public async Task<List<SuggestionSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _suggestionService.GetAll(cancellation);
        }
    }
}
