using App.Domain.Core.HomeService.CustomerEntity.AppService;
using App.Domain.Core.HomeService.CustomerEntity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages.User.Customer.Profile
{
    [Authorize(Roles = "Customer")]
    public class ChangePasswordModel : PageModel
    {
        
        private readonly ICustomerAppService _customerAppService;
        public ChangePasswordModel(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
            
        }

        [BindProperty]
        public CustomerChangePasswordDto Customer { get; set; }

        [BindProperty]
        public IdentityResult Results { get; set; }

        public async Task OnGetAsync(CancellationToken cancellation)
        {
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                Customer.Id = int.Parse(UserTools.GetUserId(User.Claims));
                Results = await _customerAppService.ChangePassword(Customer, cancellationToken);
            }

            return Page();
        }
    }
}
