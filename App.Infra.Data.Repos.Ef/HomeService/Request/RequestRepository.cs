using App.Domain.Core.HomeService.RequestEntity.Data;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Request
{
    public class RequestRepository(AppDbContext _dbContext) : IRequestRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.RequestEntity.Entities.Request request, CancellationToken cancellation)
        {
            if (request is null)
                return new Result(false, "Request Is Null");

            await _dbContext.Requests.AddAsync(request);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var request = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == id);
            if (request is null)
                return new Result(false, "Request Not Found.");

            _dbContext.Requests.Remove(request);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<RequestSummaryDto>>? GetAll(CancellationToken cancellation)
        {
            return await _dbContext.Requests.AsNoTracking().Select(x => new RequestSummaryDto()
            {
                Id = x.Id,
                DateOfCompletion = x.DateOfCompletion,
                TimeOfCompletion = x.TimeOfCompletion,
                Description = x.Description,
                CustomerId = x.CustomerId,
                Price = x.Price,
                RequestAt = x.RequestAt,
                ServiceName = x.Service.Title,
                Status = x.Status,

            }).ToListAsync();
        }

        public async Task<Domain.Core.HomeService.RequestEntity.Entities.Request>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RequestUpdateDto>? GetByIdForUpdate(int id, CancellationToken cancellation)
        {
            return await _dbContext.Requests.AsNoTracking().Select(x => new RequestUpdateDto()
            {
                Id = x.Id,
                StatusRequest = x.Status,
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(RequestUpdateDto request, CancellationToken cancellation)
        {
            var req = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (req is null)
                return new Result(false, "درخواست یافت نشد");


            req.Status = request.StatusRequest;
            
            

            await _dbContext.SaveChangesAsync();

            return new Result(true, "درخواست با موفقیت بروزرسانی شد");
        } 
    }
}
