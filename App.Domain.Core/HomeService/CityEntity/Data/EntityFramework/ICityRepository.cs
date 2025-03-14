using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.ResultEntity;

namespace App.Domain.Core.HomeService.CityEntity.Data.EntityFramework
{
    public interface ICityRepository
    {
        public Task<Result> Add(City city, CancellationToken cancellation);
        public Task<Result> Update(int id, City city, CancellationToken cancellation);
        public Task<Result> Delete(int id, CancellationToken cancellation);
        public Task<List<City>>? GetAll(CancellationToken cancellation);
        public Task<City>? GetById(int id, CancellationToken cancellation);
    }
}
