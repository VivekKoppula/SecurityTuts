using System.ComponentModel.DataAnnotations;

namespace WebAppWpRememberMe.Models
{
    public class User
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Display(Name = "Remeber Me")]
        public bool RememberMe { get; set; }
    }
}
