using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Service;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.AppServices.HomeService.Request
{
    public class RequestAppService(IRequestService _requestService) : IRequestAppService
    {
        public async Task<List<RequestSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _requestService.GetAll(cancellation);
        }

        public async Task<RequestUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _requestService.GetByIdForUpdate(id, cancellation);
        }

        public async Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation)
        {
            return await _requestService.Update(request, cancellation);
        }
    }
}
