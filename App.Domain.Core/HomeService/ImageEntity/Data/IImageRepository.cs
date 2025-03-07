using App.Domain.Core.HomeService.ImageEntity.Entities;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.ImageEntity.Data
{
    public interface IImageRepository
    {
        public Task<Result> Add(Image image, CancellationToken cancellation);
        public Task<Result> Update(int id, Image image, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Image>>? GetAll(Image image, CancellationToken cancellation);
        public Task<Image>? GetById(int id, CancellationToken cancellation);
        public Task<Result> AddReqImages(List<string> imgAddress, int reqId, CancellationToken cancellationToken);
    }
}
