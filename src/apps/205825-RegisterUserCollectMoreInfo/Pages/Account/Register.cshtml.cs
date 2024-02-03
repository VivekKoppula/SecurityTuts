using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegisterUserCollectMoreInfo.Model;
using RegisterUserCollectMoreInfo.Services;
using RegisterUserCollectMoreInfo.Data.Account;

namespace RegisterUserCollectMoreInfo.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<Student> _userManager;
        private readonly IEmailService _emailService;

        public RegisterModel(UserManager<Student> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        [BindProperty]
        public RegisterViewModel RegisterViewModel { get; set; } = new RegisterViewModel();

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var user = new Student
            {
                Email = RegisterViewModel.Email,
                UserName = RegisterViewModel.Email,
                RollNumber = RegisterViewModel.RollNumber,
                YearEnrolled = RegisterViewModel.YearEnrolled
            };

            var result = await _userManager.CreateAsync(user, RegisterViewModel.Password);

            if (result.Succeeded)
            {
                await _emailService.SendConformationEmail(user, Url);

                return RedirectToPage("/Account/RegisterSuccess");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }

                return Page();
            }
        }
    }
}
