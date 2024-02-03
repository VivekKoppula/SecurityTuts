using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppWpCookieExpiry.Pages
{
    [Authorize(Policy = "ConfirmedEnggOnly")]
    public class Engg : PageModel
    {
        public void OnGet()
        {
        }
    }
}
