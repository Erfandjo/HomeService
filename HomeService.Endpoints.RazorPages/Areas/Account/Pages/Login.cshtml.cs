using App.Domain.Core.HomeService.Config;
using App.Domain.Core.HomeService.ResultEntity;
using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Areas.Account.Pages
{

    

    public class LoginModel(SiteSettings siteSettings, IUserAppService userAppService) : PageModel
    {

        [BindProperty]
        public UserLoginModel Users { get; set; }

        //[BindProperty]
        //public Result? Result { get; set; }

        public IActionResult OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            
            var user = await userAppService.Login(Users.Username, Users.Password, true);
            //if (!Result.IsSucces)
            //{
            //    return Page();
            //}
            if (User.IsInRole("Admin"))
            {
                returnUrl = Url.Content("/Admin");
                return LocalRedirect(returnUrl);
            }
            return Page();
            
        }
    }
}
