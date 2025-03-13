using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Data.Dapper;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages
{
    public class IndexModel(ICategoryDapperRepository _categoryRepositoryDapper) : PageModel
    {

        [BindProperty]
        public List<CategorySummaryDto> Categories { get; set; }

        public async Task<IActionResult> OnGetAsync(CancellationToken cancellation , string returnUrl = null)
        {

        

            Categories = await _categoryRepositoryDapper.GetAll(cancellation);
            if (User.IsInRole("Admin"))
            {
                returnUrl = Url.Content("/Admin");
                return LocalRedirect(returnUrl);
            }
            return Page();
        }
    }
}
