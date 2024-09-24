using System.Security.Claims;

namespace TLCAREERSCORE.Domain
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }

        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Upn);
        }

        public static string GetDisplayName(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Name);
        }

        public static string GetRole(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Role);
        }

        public static string GetSid(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Sid);
        }

        public static bool IsAuthenticated(this ClaimsPrincipal principal)
        {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return principal.Identity.IsAuthenticated;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        }

        public static string GetUserCompany(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.UserData);
        }

    }
}
