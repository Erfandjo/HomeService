using App.Domain.Core.HomeService.Config;
using App.Domain.Core.HomeService.UserEntity.AppService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Account.Pages
{

    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class LoginModel(SiteSettings siteSettings, IUserAppService userAppService) : PageModel
    {

        [BindProperty]
        public LoginViewModel PageModel { get; set; }

        public IActionResult OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            
           var user = await userAppService.Login(PageModel.Username, PageModel.Password, true);
            if (User.IsInRole("Admin"))
            {
                returnUrl = Url.Content("/Admin");
                return LocalRedirect(returnUrl);
            }
            return Page();
            
        }
    }
}
