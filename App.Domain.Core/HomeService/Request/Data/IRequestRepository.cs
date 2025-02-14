using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.HomeService.Request.Data
{
    public interface IRequestRepository
    {
        public Task<Result.Result> Add(Request.Entities.Request request , CancellationToken cancellation);
        public Task<Result.Result> Update(int id, Request.Entities.Request request, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Request.Entities.Request>>? GetAll(Request.Entities.Request request, CancellationToken cancellation);
        public Task<Request.Entities.Request>? GetById(int id, CancellationToken cancellation);
    }
}
