using App.Domain.Core.HomeService.ImageEntity.Data;
using App.Domain.Core.HomeService.ResultEntity;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.HomeService.Image
{
    public class ImageRepository(AppDbContext _dbContext) : IImageRepository
    {
        public async Task<Result> Add(Domain.Core.HomeService.ImageEntity.Entities.Image image, CancellationToken cancellation)
        {
            if (image is null)
                return new Result(false, "Image Is Null");

            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<Result> Delete(int id, CancellationToken cancellation)
        {
            var image = await _dbContext.Images.FirstOrDefaultAsync(x => x.Id == id);
            if (image is null)
                return new Result(false, "Image Not Found.");

            _dbContext.Images.Remove(image);
            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }

        public async Task<List<Domain.Core.HomeService.ImageEntity.Entities.Image>>? GetAll(Domain.Core.HomeService.ImageEntity.Entities.Image image, CancellationToken cancellation)
        {
            return await _dbContext.Images.AsNoTracking().ToListAsync();
        }

        public async Task<Domain.Core.HomeService.ImageEntity.Entities.Image>? GetById(int id, CancellationToken cancellation)
        {
            return await _dbContext.Images.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> Update(int id, Domain.Core.HomeService.ImageEntity.Entities.Image image, CancellationToken cancellation)
        {
            var img = await _dbContext.Images.FirstOrDefaultAsync(x => x.Id == id);
            if (img is null)
                return new Result(false, "Image Not Found.");

            img.Path = image.Path;

            await _dbContext.SaveChangesAsync();

            return new Result(true, "Success");
        }
    }
}
