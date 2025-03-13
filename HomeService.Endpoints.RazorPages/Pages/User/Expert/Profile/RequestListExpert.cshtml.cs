using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Expert.Profile
{
    [Authorize(Roles = "Expert")]
    public class RequestListExpertModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;

        [BindProperty]
        public List<RequestExpertListDto> Requests { get; set; }

        [BindProperty]
        public Result Result { get; set; }

        public RequestListExpertModel(IRequestAppService requestAppService)
        {
            _requestAppService = requestAppService;
            Result = new Result();
        }



        public async Task OnGetAsync(CancellationToken cancellation)
        {

            Requests = await _requestAppService.GetRequestsExpert(UserTools.GetExpertId(User.Claims), cancellation);
        }

    }
}
