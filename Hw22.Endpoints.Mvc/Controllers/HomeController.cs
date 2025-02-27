using App.Domain.Core.HomeService.UserEntity.AppService;
using App.Domain.Core.HomeService.UserEntity.Entities;
using Hw22.Endpoints.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hw22.Endpoints.Mvc.Controllers
{
    public class HomeController(IUserAppService userAppService , UserManager<User> userManager) : Controller
    {
       // private readonly ILogger<HomeController> _logger;


        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index(CancellationToken cancellation)
        {
            //var result = await userAppService.Register("salam", "Et65$jd" , "Customer");
            //await userAppService.Login("salam" , "Et65$jd", false);

            //var claims = User.Claims;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
