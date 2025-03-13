using App.Domain.Core.HomeService.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeService.Endpoints.WebApi.Framework
{
    public class ApiKeyFilter : ActionFilterAttribute
    {
        private readonly SiteSettings _siteSettings;

        public ApiKeyFilter(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }

    

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKey))
            {
                context.Result = new UnauthorizedResult(); 
                return;
            }

          
            if (apiKey != _siteSettings.ApiKey)
            {
                context.Result = new UnauthorizedResult(); 
                return;
            }

            base.OnActionExecuting(context);
        }


    }
}
