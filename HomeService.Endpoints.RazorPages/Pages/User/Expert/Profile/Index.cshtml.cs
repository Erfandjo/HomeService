using App.Domain.Core.HomeService.ExpertEntity.AppService;
using App.Domain.Core.HomeService.ExpertEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Expert.Profile
{
    public class ProfileModel(IExpertAppService _expertAppService) : PageModel
    {


        public ExpertProfileDto Expert { get; set; }

        public async Task OnGetAsync(int id , CancellationToken cancellation)
        {
            Expert = await _expertAppService.GetByIdForProfile(id, cancellation);
        }
    }
}
