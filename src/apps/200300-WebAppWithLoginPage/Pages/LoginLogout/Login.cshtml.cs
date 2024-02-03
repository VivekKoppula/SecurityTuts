using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppWithLoginPage.Models;

namespace WebAppWithLoginPage.Pages.LoginLogout
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User UserCreds { get; set; } = default!;

        public void OnGet()
        {

        }

        public void OnPost()
        {

            var password = UserCreds.Password;
            var userName = UserCreds.UserName;
            // If you are using visual studio, use the following break point to 
            // check the values of name and pass.
            Debugger.Break();
            Console.WriteLine($"User Name is {userName}");
            Console.WriteLine($"Password is {password}");
        }
    }
}
