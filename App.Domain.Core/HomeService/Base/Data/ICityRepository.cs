using App.Domain.Core.HomeService.Base.Entities;

namespace App.Domain.Core.HomeService.Base.Data
{
    public interface ICityRepository
    {
        public Task<Result.Result> Add(City city, CancellationToken cancellation);
        public Task<Result.Result> Update(int id, City city, CancellationToken cancellation);
        public Task<Result.Result> Delete(int id, CancellationToken cancellation);
        public Task<List<City>>? GetAll(City city, CancellationToken cancellation);
        public Task<City>? GetById(int id, CancellationToken cancellation);
    }
}
