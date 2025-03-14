using App.Domain.AppServices.HomeService.Request;
using App.Domain.Core.HomeService.RequestEntity.AppService;
using App.Domain.Core.HomeService.RequestEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.SuggestionEntity.AppService;
using App.Domain.Core.HomeService.SuggestionEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Expert.Profile.Suggestion
{
    [Authorize(Roles = "Expert")]
    public class IndexModel : PageModel
    {
        private readonly ISuggestionAppService _suggestionAppService;
        public IndexModel(ISuggestionAppService suggestionAppService)
        {
            _suggestionAppService = suggestionAppService;
            Suggestion = new SuggestionCreateDto();
            Results = new Result();
        }

        [BindProperty]
        public SuggestionCreateDto Suggestion { get; set; }

        [BindProperty]
        public Result Results { get; set; }

        public async Task OnGetAsync(int requestId, CancellationToken cancellation)
        {
            Suggestion.RequestId = requestId;
        }


        public async Task<IActionResult> OnPost(CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                Suggestion.ExpertId = UserTools.GetExpertId(User.Claims);
                Results = await _suggestionAppService.Add(Suggestion, cancellation);

                if (Results.IsSucces)
                {
                    return RedirectToPage("/User/Expert/Profile/RequestListExpert");
                }

                return Page();
            }

            return Page();
        }
    }
}
