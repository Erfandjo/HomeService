using App.Domain.Core.HomeService.Result;
using App.Domain.Core.HomeService.Service.Data;
using App.Domain.Core.HomeService.SubCategory.Entities;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Service
{
    public class ServiceRepository(AppDbContext _dbContext) : IServiceRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.Service.Entities.Service service, CancellationToken cancellation)
        {
            if (service is null)
                return new Result(false, "Service Is Null");

            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var service = await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service is null)
                return new Result(false, "Service Not Found.");

            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<Domain.Core.HomeService.Service.Entities.Service>>? GetAll(Domain.Core.HomeService.Service.Entities.Service service, CancellationToken cancellation)
        {
            return await _dbContext.Services.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.Service.Entities.Service>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Services.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.Service.Entities.Service service, CancellationToken cancellation)
        {
            var ser = await _dbContext.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (ser is null)
                return new Result(false, "Service Not Found.");

            ser.Title = service.Title;
            ser.VisitCount = service.VisitCount;
            ser.SubCategoryId = service.SubCategoryId;
            ser.BasePrice = service.BasePrice;
            ser.ImagePath = service.ImagePath;
            
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
