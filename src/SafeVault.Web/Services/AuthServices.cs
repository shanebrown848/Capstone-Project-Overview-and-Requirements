using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using SafeVault.Web.Models;

namespace SafeVault.Web.Services
{
    public class AuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // Registers a new user with hashed password
        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password)
        {
            // Here, you might add additional validation using ValidationHelpers
            return await _userManager.CreateAsync(user, password);
        }

        // Login method can include additional logic (e.g., generating JWT tokens)
        public async Task<bool> ValidateUserCredentialsAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return await _userManager.CheckPasswordAsync(user, password);
            }
            return false;
        }
    }
}
