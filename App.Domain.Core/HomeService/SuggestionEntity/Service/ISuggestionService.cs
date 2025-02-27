using App.Domain.Core.HomeService.SuggestionEntity.Dto;

namespace App.Domain.Core.HomeService.SuggestionEntity.Service
{
    public interface ISuggestionService
    {
        public Task<List<SuggestionSummaryDto>>? GetAll(CancellationToken cancellation);
    }
}
