using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.ExpertEntity.Data
{
    public interface IExpertRepository
    {
        public Task<Result> Add(Entities.Expert expert, CancellationToken cancellation);
        public Task<Result> Update(int id, Entities.Expert expert, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Entities.Expert>>? GetAll(Entities.Expert expert, CancellationToken cancellation);
        public Task<Entities.Expert>? GetById(int id, CancellationToken cancellation);
    }
}
