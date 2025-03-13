using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Entities;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.RequestEntity.Data
{
    public interface IRequestRepository
    {
        public Task<Result> Add(RequestCreateDto request, CancellationToken cancellation);
        public Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<RequestSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Request>? GetById(int id, CancellationToken cancellation);
        public Task<RequestUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
        public Task<List<RequestCustomerListDto>>? GetRequestsCustomer(int customerId , CancellationToken cancellation);
        public Task<Result> AcceptSuggestion(int requestId ,  CancellationToken cancellation);
        public Task<Result> FinishRequest(int requestId, CancellationToken cancellation);
        public Task<Result> PaidRequest(int requestId, CancellationToken cancellation);
        public Task<Result> BackStatusWaiting(int requestId, CancellationToken cancellation);
        public Task<Result> BackStatusSelection(int requestId, CancellationToken cancellation);
        public Task<Result> BackStatusFinish(int requestId, CancellationToken cancellation);
        public Task<List<RequestExpertListDto>>? GetRequestsExpert(List<int> expetSkils , CancellationToken cancellation);
    }
}
