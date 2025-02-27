using App.Domain.Core.HomeService.CityEntity.Data;
using App.Domain.Core.HomeService.CityEntity.Service;

namespace App.Domain.Services.HomeService.City
{
    public class CityService(ICityRepository _cityRepository) : ICityService
    {
        public async Task<List<Core.HomeService.CityEntity.Entities.City>>? GetAll(CancellationToken cancellation)
        {
          return await _cityRepository.GetAll(cancellation);
        }
    }
}
