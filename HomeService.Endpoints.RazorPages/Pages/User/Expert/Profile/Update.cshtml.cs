using App.Domain.AppServices.HomeService.Customer;
using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.CustomerEntity.AppService;
using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.ExpertEntity.AppService;
using App.Domain.Core.HomeService.ExpertEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Expert.Profile
{
    [Authorize(Roles = "Expert")]
    public class UpdateModel : PageModel
    {

        private readonly IExpertAppService _expertAppService;
        private readonly ICityAppService _cityAppService;


        public UpdateModel(IExpertAppService expertAppService, ICityAppService cityAppService)
        {
            _cityAppService = cityAppService;
            _expertAppService = expertAppService;
            Results = new Result();
        }

        [BindProperty]
        public ExpertUpdateDto Expert { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; }

        [BindProperty]
        public Result Results { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)
        {
            Expert = await _expertAppService.GetByIdForUpdate(UserTools.GetExpertId(User.Claims), cancellation);
            Cities = await _cityAppService.GetAll(cancellation);
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellation)
        {
            if (ModelState.IsValid)
            {
                Results = await _expertAppService.Update(Expert, cancellation);
                if (!Results.IsSucces)
                {
                    Cities = await _cityAppService.GetAll(cancellation);
                    return Page();
                }
            
            }
            Cities = await _cityAppService.GetAll(cancellation);
            return Page();

        }
    }
}
