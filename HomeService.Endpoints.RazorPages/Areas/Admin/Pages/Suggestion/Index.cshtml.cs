using App.Domain.AppServices.HomeService.Suggestion;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.SuggestionEntity.AppService;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Suggestion
{
    [Authorize(Roles = "Admin")]
    public class IndexModel(ISuggestionAppService _SuggestionAppService) : PageModel
    {
      

    

        [BindProperty]
        public List<SuggestionSummaryDto> Suggestions { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)

        {
            Suggestions = await _SuggestionAppService.GetAll(cancellation);
        }



        //public async Task<IActionResult> OnGetDeleteAsync(int id, CancellationToken cancellation)
        //{
        //    var result = await _categoryAppService.Delete(id, cancellation);
        //    return RedirectToAction("OnGet");
        //}
    }
}
