using App.Domain.Core.HomeService.SubCategoryEntity.AppService;
using App.Domain.Core.HomeService.SubCategoryEntity.Data;
using App.Domain.Core.HomeService.SubCategoryEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.SubCategory
{
    public class IndexModel(ISubCategoryDapperRepository _subCategoryDapperRepository) : PageModel
    {

        [BindProperty]
        public List<SubCategorySummaryDto> SubCategories { get; set; }

        public async Task OnGetAsync(int id , CancellationToken cancellation)
        {
           SubCategories = await _subCategoryDapperRepository.GetByCategoryId(id , cancellation);
        }
    }
}
