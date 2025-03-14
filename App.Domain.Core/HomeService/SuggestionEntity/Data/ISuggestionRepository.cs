using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;

namespace App.Domain.Core.HomeService.SuggestionEntity.Data
{
    public interface ISuggestionRepository
    {
        public Task<Result> Add(SuggestionCreateDto suggestion, CancellationToken cancellation);
        public Task<Result> Update(int id, Entities.Suggestion suggestion, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<SuggestionSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Entities.Suggestion>? GetById(int id, CancellationToken cancellation);
        //public Task<List<SuggestionRequestListDto>>? GetSuggestionRequest(int requestId, CancellationToken cancellation);
        public Task<Result> AcceptSuggestion(int suggestionId, CancellationToken cancellation);
        public Task<Result> FinishSuggestion(int suggestionId, CancellationToken cancellation);
        public Task<Result> PaidSuggestion(int suggestionId, CancellationToken cancellation);
    }
}
