using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;

namespace App.Domain.Core.HomeService.SuggestionEntity.Service
{
    public interface ISuggestionService
    {
        public Task<List<SuggestionSummaryDto>>? GetAll(CancellationToken cancellation);
        //public Task<List<SuggestionRequestListDto>>? GetSuggestionRequest(int requestId, CancellationToken cancellation);
        public Task<Result> AcceptSuggestion(int suggestionId, CancellationToken cancellation);
        public Task<Result> FinishSuggestion(int suggestionId, CancellationToken cancellation);
        public Task<Result> PaidSuggestion(int suggestionId, CancellationToken cancellation);
    }
}
