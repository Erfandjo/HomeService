using App.Domain.Core.HomeService.CityEntity.Entities;

namespace App.Domain.Core.HomeService.CityEntity.AppService
{
    public interface ICityAppService
    {
        public Task<List<City>>? GetAll(CancellationToken cancellation);
    }
}
