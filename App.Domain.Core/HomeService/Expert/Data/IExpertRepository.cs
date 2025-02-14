namespace App.Domain.Core.HomeService.Expert.Data
{
    public interface IExpertRepository
    {
        public Task<Result.Result> Add(Expert.Entities.Expert expert , CancellationToken cancellation);
        public Task<Result.Result> Update(int id, Expert.Entities.Expert expert, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<Expert.Entities.Expert>>? GetAll(Expert.Entities.Expert expert, CancellationToken cancellation);
        public Task<Expert.Entities.Expert>? GetById(int id, CancellationToken cancellation);
    }
}
