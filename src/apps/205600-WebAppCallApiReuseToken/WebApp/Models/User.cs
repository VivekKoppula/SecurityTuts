using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System;

namespace WebApp.Models
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

    public class JwtToken
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; } = default!;

        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }
    }

}
