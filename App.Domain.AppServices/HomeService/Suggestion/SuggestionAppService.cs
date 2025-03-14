using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SuggestionEntity.AppService;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using App.Domain.Core.HomeService.SuggestionEntity.Service;

namespace App.Domain.AppServices.HomeService.Suggestion
{
    public class SuggestionAppService(ISuggestionService _suggestionService) : ISuggestionAppService
    {
        public async Task<Result> Add(SuggestionCreateDto suggestion, CancellationToken cancellation)
        {
            suggestion.Status = Core.HomeService.SuggestionEntity.Enum.StatusSuggestionEnum.NotSelection;
            suggestion.SuggestionAt = DateTime.Now;
            return await _suggestionService.Add(suggestion, cancellation);
        }

        public async Task<List<SuggestionSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _suggestionService.GetAll(cancellation);
        }
    }
}
