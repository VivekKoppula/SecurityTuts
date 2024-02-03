using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppWpAuthorizeService.Pages
{
    public class JQueryTestsModel : PageModel
    {
        private readonly ILogger<JQueryTestsModel> _logger;

        public JQueryTestsModel(ILogger<JQueryTestsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}