﻿using System.ComponentModel.DataAnnotations;

namespace WebAppWithLoginPage.Models
{
    public class User
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } = default!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
    }
}
