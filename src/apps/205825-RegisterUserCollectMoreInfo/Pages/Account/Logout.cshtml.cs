using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegisterUserCollectMoreInfo.Data.Account;

namespace RegisterUserCollectMoreInfo.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<Student> signInManager;

        public LogoutModel(SignInManager<Student> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/Account/Login");
        }
    }
}
