using Microsoft.AspNetCore.Identity;

namespace RegisterUserCollectMoreInfo.Data.Account
{
    public class Student : IdentityUser
    {
        public int YearEnrolled { get; set; } 
        public string RollNumber { get; set; } = default!;
    }
}
