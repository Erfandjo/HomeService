using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Dto;

namespace App.Domain.Core.HomeService.RequestEntity.AppService
{
    public interface IRequestAppService
    {
        public Task<List<RequestSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation);
        public Task<RequestUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<Result> Add(RequestCreateDto request, CancellationToken cancellation);
        public Task<List<RequestListCustomerDto>>? GetRequestsCustomer(int customerId, CancellationToken cancellation);
        public Task<Result> AcceptSuggestion(int requestId , int suggestionId , CancellationToken cancellation);
        public Task<Result> FinishSuggestion(int requestId, int suggestionId, CancellationToken cancellation);
        public Task<Result> PaidSuggestion(int requestId, int suggestionId, int customerId, string price, CancellationToken cancellation);
    }
}
