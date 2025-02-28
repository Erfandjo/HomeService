using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeService.Endpoints.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        

        public async Task<IActionResult> OnGetAsync(string returnUrl = null)
        {
            
            if (User.IsInRole("Admin"))
            {
                returnUrl = Url.Content("/Admin");
                return LocalRedirect(returnUrl);
            }
            return Page();
        }
    }
}
