
using App.Domain.Core.HomeService.Base.Entities;

namespace App.Domain.Core.HomeService.Base.Data
{
    public interface IImageRepository
    {
        public Task<Result.Result> Add(Image image, CancellationToken cancellation);
        public Task<Result.Result> Update(int id, Image image, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Image>>? GetAll(Image image, CancellationToken cancellation);
        public Task<Image>? GetById(int id, CancellationToken cancellation);
    }
}
