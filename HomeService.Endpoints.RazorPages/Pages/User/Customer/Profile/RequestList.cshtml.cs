using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Customer.Profile
{
    public class RequestListModel: PageModel
    {

        private readonly IRequestAppService _requestAppService;

        public RequestListModel(IRequestAppService requestAppService)
        {
            _requestAppService = requestAppService;
            Result = new Result();
        }

        [BindProperty]
        public List<RequestListCustomerDto> Requests { get; set; }

        [BindProperty]
        public Result Result { get; set; }


        public async Task OnGetAsync(CancellationToken cancellation)
        {
            
            Requests = await _requestAppService.GetRequestsCustomer(UserTools.GetCustomerId(User.Claims) , cancellation);
        }


        public async Task<IActionResult> OnGetAcceptAsync(int requestId , int suggestionId, CancellationToken cancellation)
        {
            Result = await _requestAppService.AcceptSuggestion(requestId , suggestionId, cancellation);
            Requests = await _requestAppService.GetRequestsCustomer(UserTools.GetCustomerId(User.Claims), cancellation);
            return Page();
        }

        public async Task<IActionResult> OnGetFinishAsync(int requestId, int suggestionId, CancellationToken cancellation)
        {
            Result = await _requestAppService.FinishSuggestion(requestId, suggestionId, cancellation);
            Requests = await _requestAppService.GetRequestsCustomer(UserTools.GetCustomerId(User.Claims), cancellation);
            return Page();
        }


        public async Task<IActionResult> OnGetPaymentAsync(int requestId, int suggestionId , int expertId , string price , CancellationToken cancellation)
        {
            Result = await _requestAppService.PaidSuggestion(requestId , suggestionId , UserTools.GetCustomerId(User.Claims) , price , cancellation);
            Requests = await _requestAppService.GetRequestsCustomer(UserTools.GetCustomerId(User.Claims), cancellation);
            return Page();
        }
    }
}
