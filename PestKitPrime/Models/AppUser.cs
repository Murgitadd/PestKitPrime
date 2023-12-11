using Microsoft.AspNetCore.Identity;

namespace PestKitPrime.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
