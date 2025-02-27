using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.RequestEntity.AppService
{
    public interface IRequestAppService
    {
        public Task<List<RequestSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation);
        public Task<RequestUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
    }
}
