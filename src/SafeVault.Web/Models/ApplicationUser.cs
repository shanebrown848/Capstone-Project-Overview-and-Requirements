using Microsoft.AspNetCore.Identity;

namespace SafeVault.Web.Models
{
    // Extend IdentityUser to add custom properties if needed
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
