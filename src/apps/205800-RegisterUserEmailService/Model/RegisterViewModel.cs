using System.ComponentModel.DataAnnotations;

namespace RegisterUserEmailService.Model
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = default!;

        [Required]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; } = default!;
    }

    public class CredentialViewModel
    {
        [Required]
        public string Email { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Display(Name = "Remeber Me")]
        public bool RememberMe { get; set; } = default!;
    }

}
