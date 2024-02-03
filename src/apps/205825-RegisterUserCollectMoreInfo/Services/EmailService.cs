using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegisterUserCollectMoreInfo.Data.Account;
using System.Net;
using System.Net.Mail;

namespace RegisterUserCollectMoreInfo.Services
{
    public interface IEmailService
    {
        Task SendConformationEmail(Student user, IUrlHelper urlHelper);
    }
    public class EmailService : IEmailService
    {
        private readonly UserManager<Student> _userManager;

        public EmailService(UserManager<Student> userManager)
        {
            _userManager = userManager;
        }

        public async Task SendConformationEmail(Student user, IUrlHelper urlHelper)
        {
            var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = urlHelper.PageLink(pageName: "/Account/ConfirmEmail",
                values: new { userId = user.Id, token = confirmationToken });

            var messagee = new MailMessage("vivek@gmail.com", user.Email,
                "Please confirm your email",
                $"Please click on this link to confirm your email address: {confirmationLink}");

            using (var emailClient = new SmtpClient("localhost", 1025))
            {
                emailClient.Credentials = new NetworkCredential(
                    "vivek@gmail.com",
                    "VqaRACgdU3Xp5cWB");

                await emailClient.SendMailAsync(messagee);
            }
        }
    }
}
