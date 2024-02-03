using System.ComponentModel.DataAnnotations;

namespace WebAppRegisterUser.Model
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

}
