using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Service;

namespace App.Domain.AppServices.HomeService.City
{
    public class CityAppService(ICityService _cityService) : ICityAppService
    {
        public async Task<List<Core.HomeService.CityEntity.Entities.City>>? GetAll(CancellationToken cancellation)
        {
          return await  _cityService.GetAll(cancellation);
        }
    }
}
