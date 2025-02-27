using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Entities;
using App.Domain.Core.HomeService.ResultEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.RequestEntity.Data
{
    public interface IRequestRepository
    {
        public Task<Result> Add(Request request, CancellationToken cancellation);
        public Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<RequestSummaryDto>>? GetAll(CancellationToken cancellation);
        public Task<Request>? GetById(int id, CancellationToken cancellation);
        public Task<RequestUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation);
    }
}
