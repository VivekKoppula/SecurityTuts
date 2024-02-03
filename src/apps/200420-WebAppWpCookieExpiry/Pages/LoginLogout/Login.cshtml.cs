using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Security.Claims;
using WebAppWpCookieExpiry;
using WebAppWpCookieExpiry.Models;

namespace WebAppWpCookieExpiry.Pages.LoginLogout
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User UserCreds { get; set; } = default!;

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page(); // Return the same view.

            // Verify the credential
            if (UserCreds.UserName == "admin" && UserCreds.Password == "123")
            {
                // Creating the security context
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, "admin"),
                    new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
                    new Claim("Dept", "Hr"),
                    new Claim("Dept", "Engg"),
                    // new Claim("Manager", "true"),
                    new Claim("EmploymentDate", "2022-02-01")
                };

                var identity = new ClaimsIdentity(claims, Constants.AuthTypeSchemeName);

                // We are creating the claims principal, which is the security context.
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // Console.WriteLine($"The authenticated status {HttpContext.User.Identity!.IsAuthenticated}");

                try
                {

                    // So now SignInAsync here is serializing the claimsPrincipal, encrypt it, and then 
                    // save that as a cookie and send that back in the response.
                    await HttpContext.SignInAsync(Constants.AuthTypeSchemeName, claimsPrincipal);
                }
                catch (Exception ex)
                {
                    Debugger.Break();
                    var message = ex.Message;
                    throw new Exception(message);
                }

                return RedirectToPage("/Index");
            }

            return Page(); // Return the same view;
        }
    }
}
