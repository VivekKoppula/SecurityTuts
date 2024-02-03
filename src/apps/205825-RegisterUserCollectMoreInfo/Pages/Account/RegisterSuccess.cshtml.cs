using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegisterUserCollectMoreInfo.Data.Account;
using RegisterUserCollectMoreInfo.Model;

namespace RegisterUserCollectMoreInfo.Pages.Account
{
    public class RegisterSuccessModel : PageModel
    {
        private readonly UserManager<Student> userManager;

        public RegisterSuccessModel(UserManager<Student> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; } = new RegisterViewModel();

        public void OnGet()
        {

        }
    }
}
