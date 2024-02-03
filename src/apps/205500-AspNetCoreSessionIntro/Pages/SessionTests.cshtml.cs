using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreSessionIntro.Pages;

public class SessionTests : PageModel
{
    public const string SessionKeyName = "_Name";
    public const string SessionKeyAge = "_Age";
    public const string SessionKeyRandomGuid = "_RandomGuid";

    private readonly ILogger<IndexModel> _logger;

    public SessionTests(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public void OnPostAddItemsToSession()
    {
        HttpContext.Session.SetString(SessionKeyName, "The Doctor");
        HttpContext.Session.SetInt32(SessionKeyAge, 73);

        if (string.IsNullOrWhiteSpace(HttpContext.Session.GetString(SessionKeyRandomGuid)))
        {
            HttpContext.Session.SetString(SessionKeyRandomGuid, Guid.NewGuid().ToString());
        }
    }
    public void OnPostRemoveItemsFromSession()
    {
        HttpContext.Session.Clear();
    }

    public void OnPostRefreshGoToServer() 
    {

    }
}
