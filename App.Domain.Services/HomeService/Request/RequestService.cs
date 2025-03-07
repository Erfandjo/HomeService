using App.Domain.Core.HomeService.RequestEntity.Data;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Services.HomeService.Request
{
    public class RequestService(IRequestRepository _requestRepository) : IRequestService
    {
        public async Task<Result> AcceptSuggestion(int requestId, CancellationToken cancellation)
        {
            return await _requestRepository.AcceptSuggestion(requestId, cancellation);
        }

        public async Task<Result> Add(RequestCreateDto request, CancellationToken cancellation)
        {
            return await _requestRepository.Add(request, cancellation);
        }

        public async Task<Result> BackStatusFinish(int requestId, CancellationToken cancellation)
        {
            return await _requestRepository.BackStatusFinish(requestId, cancellation);
        }

        public async Task<Result> BackStatusSelection(int requestId, CancellationToken cancellation)
        {
            return await _requestRepository.BackStatusSelection(requestId, cancellation);
        }

        public async Task<Result> BackStatusWaiting(int requestId, CancellationToken cancellation)
        {
            return await _requestRepository.BackStatusWaiting(requestId, cancellation);
        }

        public async Task<Result> FinishRequest(int requestId, CancellationToken cancellation)
        {
            return await _requestRepository.FinishRequest(requestId, cancellation);
        }

        public async Task<List<RequestSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _requestRepository.GetAll(cancellation);
        }

        public async Task<Core.HomeService.RequestEntity.Entities.Request>? GetById(int id, CancellationToken cancellation)
        {
            return await _requestRepository.GetById(id, cancellation);
        }

        public async Task<RequestUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _requestRepository.GetByIdForUpdate(id, cancellation);
        }

        public async Task<List<RequestListCustomerDto>>? GetRequestsCustomer(int customerId, CancellationToken cancellation)
        {
            return await _requestRepository.GetRequestsCustomer(customerId, cancellation);
        }

        public async Task<Result> PaidRequest(int requestId, CancellationToken cancellation)
        {
            return await _requestRepository.PaidRequest(requestId, cancellation);
        }

        public async Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation)
        {
            return await _requestRepository.Update(request, cancellation);
        }
    }
}
