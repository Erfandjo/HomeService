using App.Domain.Core.HomeService.CategoryEntity.AppService;
using App.Domain.Core.HomeService.CategoryEntity.Dto;
using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using App.Domain.Core.HomeService.UserEntity.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Admin.Pages.Category
{
    [Authorize(Roles = "Admin")]
    public class CreateModel(ICategoryAppService _categoryAppService) : PageModel
    {


        [BindProperty]
        public CategoryCreateDto Category { get; set; }


        //public async Task OnGetAsync(CancellationToken cancellationToken)
        //{
            
        //}


        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _categoryAppService.Add(Category, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}
