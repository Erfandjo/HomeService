using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using HomeService.Endpoints.WebApi.Framework;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.Endpoints.WebApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    [TypeFilter(typeof(ApiKeyFilter))]
    public class RequestController(IRequestAppService _requestAppService) : ControllerBase
    {


        [HttpGet("[action]")]
        public async Task<List<RequestSummaryDto>> GetRequests(CancellationToken cancellation)
        {
            var requests = await _requestAppService.GetAll(cancellation);
            return requests;
        }

    }
}
