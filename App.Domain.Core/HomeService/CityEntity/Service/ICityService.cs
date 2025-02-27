using App.Domain.Core.HomeService.CityEntity.Entities;

namespace App.Domain.Core.HomeService.CityEntity.Service
{
    public interface ICityService
    {
        public Task<List<City>>? GetAll(CancellationToken cancellation);
    }
}
