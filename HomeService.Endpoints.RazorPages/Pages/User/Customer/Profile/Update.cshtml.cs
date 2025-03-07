using App.Domain.AppServices.HomeService.City;
using App.Domain.Core.HomeService.CityEntity.AppService;
using App.Domain.Core.HomeService.CityEntity.Entities;
using App.Domain.Core.HomeService.CustomerEntity.AppService;
using App.Domain.Core.HomeService.CustomerEntity.Dto;
using App.Domain.Core.HomeService.ResultEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace HomeService.Endpoints.RazorPages.Pages.User.Customer.Profile
{
    public class EditProfileModel : PageModel
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly ICityAppService _cityAppService;


        public EditProfileModel(ICustomerAppService customerAppService , ICityAppService cityAppService)
        {
            _cityAppService = cityAppService;
            _customerAppService = customerAppService;
            Results = new Result();
        }

        [BindProperty]
        public CustomerUpdateDto Customer { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; }

        [BindProperty]
        public Result Results { get; set; }


        public async Task OnGetAsync(CancellationToken cancellation)
        {
            Customer = await _customerAppService.GetByIdForUpdate(UserTools.GetCustomerId(User.Claims), cancellation);
            Cities = await _cityAppService.GetAll(cancellation);
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellation)
        {
                Results = await _customerAppService.Update(Customer, cancellation);
                Cities = await _cityAppService.GetAll(cancellation);
                return Page();
            
        }

       
    }
}
