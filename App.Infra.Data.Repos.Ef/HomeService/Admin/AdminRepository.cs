using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Admin
{
    //public class AdminRepository(AppDbContext _dbContext) : IAdminRepository
    //{
    //    public async Task<Result> Add(Domain.Core.HomeService.Admin.Entities.Admin admin, CancellationToken cancellation)
    //    {
    //        if (admin is null)
    //            return new Result(false, "Admin Is Null");

    //        await _dbContext.Admins.AddAsync(admin);
    //        await _dbContext.SaveChangesAsync();

    //        return new Result(true, "Success");
    //    }

    //    public async Task<Result> Delete(int id, CancellationToken cancellation)
    //    {
    //        var admin = await _dbContext.Admins.FirstOrDefaultAsync(x => x.Id == id);
    //        if (admin is null)
    //            return new Result(false, "Admin Not Found.");

    //        _dbContext.Admins.Remove(admin);
    //        await _dbContext.SaveChangesAsync();

    //        return new Result(true, "Success");
    //    }

    //    public async Task<List<Domain.Core.HomeService.Admin.Entities.Admin>>? GetAll(Domain.Core.HomeService.Admin.Entities.Admin admin, CancellationToken cancellation)
    //    {
    //        return await _dbContext.Admins.AsNoTracking().ToListAsync();
    //    }

    //    public async Task<Domain.Core.HomeService.Admin.Entities.Admin>? GetById(int id, CancellationToken cancellation)
    //    {
    //        return await _dbContext.Admins.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    //    }

    //    public async Task<Result> Update(int id, Domain.Core.HomeService.Admin.Entities.Admin admin, CancellationToken cancellation)
    //    {
    //        var adm = await _dbContext.Admins.FirstOrDefaultAsync(x => x.Id == id);
    //        if (adm is null)
    //            return new Result(false, "Admin Not Found.");




    //        await _dbContext.SaveChangesAsync();

    //        return new Result(true, "Success");
    //    }
    //}
}
