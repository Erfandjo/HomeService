using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Category
{
    [Authorize(Roles = "Admin")]
    public class UpdateModel(ICategoryAppService _categoryAppService) : PageModel
    {
        [BindProperty]
        public CategoryUpdateDto Category { get; set; }
        



        public async Task OnGetAsync(int id, CancellationToken cancellation)
        {
            Category = await _categoryAppService.GetByIdForUpdate(id, cancellation);
            
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _categoryAppService.Update(Category, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
