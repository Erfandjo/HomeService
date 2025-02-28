using App.Domain.Core.HomeService.RequestEntity.Data;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Services.HomeService.Request
{
    public class RequestService(IRequestRepository _requestRepository) : IRequestService
    {
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

        public async Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation)
        {
            return await _requestRepository.Update(request, cancellation);
        }
    }
}
