using System.Security.Claims;

namespace HomeService.Endpoints.RazorPages
{
    public static class UserTools
    {
        public static string GetUserId(IEnumerable<Claim> claims)
        {
            return claims.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
        }

        public static int GetCustomerId(IEnumerable<Claim> claims)
        {
            return Convert.ToInt32(claims.FirstOrDefault(x => x.Type == "CustomerId").Value);
        }

        
    }
}
