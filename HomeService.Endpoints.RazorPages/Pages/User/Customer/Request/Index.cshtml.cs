using App.Domain.Core.HomeService.CategoryEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Services.HomeService.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Customer.Request
{
    [Authorize(Roles = "Customer")]
    public class IndexModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;
        public IndexModel(IRequestAppService requestAppService)
        {
            _requestAppService = requestAppService;
            Request = new RequestCreateDto();
            Results = new Result();
        }

        [BindProperty]
        public RequestCreateDto Request { get; set; }

        public Result Results { get; set; }



        public async Task OnGetAsync(int id , CancellationToken cancellation)
        {
            Request.ServiceId = id;
            
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellation)
        {
            if(ModelState.IsValid)
            {
                Request.CustomerId = UserTools.GetCustomerId(User.Claims);
                Results = await _requestAppService.Add(Request, cancellation);

                if (Results.IsSucces)
                {
                    return RedirectToPage("/User/Customer/Profile/RequestList");
                }

                return Page();
            }
         
            return Page();
        }
    }
}
