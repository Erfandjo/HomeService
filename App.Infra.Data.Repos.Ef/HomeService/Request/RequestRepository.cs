using App.Domain.Core.HomeService.Category.Entities;
using App.Domain.Core.HomeService.Request.Data;
using App.Domain.Core.HomeService.Result;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Request
{
    public class RequestRepository(AppDbContext _dbContext) : IRequestRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.Request.Entities.Request request, CancellationToken cancellation)
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

        public async Task<List<Domain.Core.HomeService.Request.Entities.Request>>? GetAll(Domain.Core.HomeService.Request.Entities.Request request, CancellationToken cancellation)
        {
            return await _dbContext.Requests.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.Request.Entities.Request>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Requests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.Request.Entities.Request request, CancellationToken cancellation)
        {
            var req = await _dbContext.Requests.FirstOrDefaultAsync(x => x.Id == id);
            if (req is null)
                return new Result(false, "Request Not Found.");


            req.Suggestions = request.Suggestions;
            req.CustomerId = request.CustomerId;
            req.Description = request.Description;
            req.Images = request.Images;
            req.DateOfCompletion = request.DateOfCompletion;
            req.TimeOfCompletion = request.TimeOfCompletion;
            
            

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
