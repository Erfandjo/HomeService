using App.Domain.Core.HomeService.CityEntity.Data.Dapper;
using App.Domain.Core.HomeService.CityEntity.Data.EntityFramework;
using App.Domain.Core.HomeService.CityEntity.Service;

namespace App.Domain.Services.HomeService.City
{
    public class CityService(ICityRepository _cityRepository , ICityDapperRepository _cityDapperRepository) : ICityService
    {
        public async Task<List<Core.HomeService.CityEntity.Entities.City>>? GetAll(CancellationToken cancellation)
        {
          return await _cityDapperRepository.GetAll(cancellation);
        }
    }
}
