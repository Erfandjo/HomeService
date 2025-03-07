using App.Domain.Core.HomeService.SuggestionEntity.Dto;

namespace App.Domain.Core.HomeService.SuggestionEntity.AppService
{
    public interface ISuggestionAppService
    {
        public Task<List<SuggestionSummaryDto>>? GetAll(CancellationToken cancellation);
       // public Task<List<SuggestionRequestListDto>>? GetSuggestionRequest(int requestId , CancellationToken cancellation);
    }
}
