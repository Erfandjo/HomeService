using App.Domain.Core.HomeService.ImageEntity.Entities;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.RequestEntity.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Expert.Profile
{
    [Authorize(Roles = "Expert")]
    public class RequestDetailsModel(IRequestAppService _requestAppService) : PageModel
    {
        [BindProperty]
        public RequestDetailDto RequestDetail { get; set; }


        public async Task OnGetAsync(int requestId, CancellationToken cancellation)
        {
            RequestDetail = await _requestAppService.GetRequestDetails(requestId, cancellation);
        }
    }
}
