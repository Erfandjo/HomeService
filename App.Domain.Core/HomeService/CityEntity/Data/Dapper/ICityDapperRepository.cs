using App.Domain.Core.HomeService.CityEntity.Entities;

namespace App.Domain.Core.HomeService.CityEntity.Data.Dapper
{
    public interface ICityDapperRepository
    {
        public Task<List<City>> GetAll(CancellationToken cancellation);
    }
}
