using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppWpCustomRequirement.Pages
{
    [Authorize(Policy = "MustBelongToHrDept")]
    public class HrModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
