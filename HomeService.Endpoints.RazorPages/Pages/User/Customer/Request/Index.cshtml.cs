using App.Domain.Core.HomeService.CategoryEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Services.HomeService.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Customer.Request
{
    public class IndexModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;
        public IndexModel(IRequestAppService requestAppService)
        {
            _requestAppService = requestAppService;
            Request = new RequestCreateDto();
        }

        [BindProperty]
        public RequestCreateDto Request { get; set; }
        


        public async Task OnGetAsync(int id , CancellationToken cancellation)
        {
            Request.ServiceId = id;
            
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellation)
        {
            Request.CustomerId = UserTools.GetCustomerId(User.Claims);
            var result = await _requestAppService.Add(Request, cancellation);
            return RedirectToPage("/Profile");
        }
    }
}
