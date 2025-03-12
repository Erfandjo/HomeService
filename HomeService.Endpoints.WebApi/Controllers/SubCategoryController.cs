using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.Endpoints.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubCategoryController(ISubCategoryAppService _subCategoryAppService) : ControllerBase
    {

        [HttpGet("[action]")]
        public async Task<List<SubCategoryApiDto>> GetSubCategories(CancellationToken cancellation)
        {
            var subCategory = await _subCategoryAppService.GetForApi(cancellation);
            return subCategory;
        }


    }
}
