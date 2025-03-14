using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SuggestionEntity.Data;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using App.Domain.Core.HomeService.SuggestionEntity.Service;

namespace App.Domain.Services.HomeService.Suggestion
{
    public class SuggestionService(ISuggestionRepository _suggestionRepository) : ISuggestionService
    {
        public async Task<Result> AcceptSuggestion(int suggestionId, CancellationToken cancellation)
        {
            return await _suggestionRepository.AcceptSuggestion(suggestionId, cancellation);
        }

        public async Task<Result> Add(SuggestionCreateDto suggestion, CancellationToken cancellation)
        {
            return await _suggestionRepository.Add(suggestion, cancellation);
        }

        public async Task<Result> FinishSuggestion(int suggestionId, CancellationToken cancellation)
        {
            return await _suggestionRepository.FinishSuggestion(suggestionId, cancellation);
        }

        public async Task<List<SuggestionSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _suggestionRepository.GetAll(cancellation);
        }

        public async Task<Result> PaidSuggestion(int suggestionId, CancellationToken cancellation)
        {
            return await _suggestionRepository.PaidSuggestion(suggestionId, cancellation);
        }
    }
}
