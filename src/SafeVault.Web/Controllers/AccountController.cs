using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SafeVault.Web.Models;
using SafeVault.Web.Services;

namespace SafeVault.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        private readonly RoleService _roleService;

        public AccountController(AuthService authService, RoleService roleService)
        {
            _authService = authService;
            _roleService = roleService;
        }

        // Display registration form
        [HttpGet]
        public IActionResult Register()
        {
            return View(); // You can use a Razor view or simply serve webform.html as static content
        }

        // Process registration form submission
        [HttpPost]
        public async Task<IActionResult> Register(string username, string name, string email, string password, string confirmPassword, string phone)
        {
            if (password != confirmPassword)
            {
                ModelState.AddModelError("confirmPassword", "Passwords do not match.");
                return View();
            }

            var user = new ApplicationUser
            {
                UserName = username,
                Name = name,
                Email = email,
                Phone = phone
            };

            var result = await _authService.RegisterUserAsync(user, password);
            if (result.Succeeded)
            {
                // Optionally assign a default role (e.g., "User")
                await _roleService.AssignRoleAsync(user, "User");
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View();
        }

        // Display login form
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Process login form submission
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var isValid = await _authService.ValidateUserCredentialsAsync(username, password);
            if (isValid)
            {
                // Set authentication cookie or generate JWT (if applicable)
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }
    }
}
