using NUnit.Framework;
using Microsoft.AspNetCore.Identity;
using Moq;
using System.Threading.Tasks;
using SafeVault.Web.Models;
using SafeVault.Web.Services;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestAuth
    {
        private AuthService _authService;
        private Mock<UserManager<ApplicationUser>> _userManagerMock;

        [SetUp]
        public void Setup()
        {
            var store = new Mock<IUserStore<ApplicationUser>>();
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
            _authService = new AuthService(_userManagerMock.Object);
        }

        [Test]
        public async Task RegisterUserAsync_ValidUser_ReturnsSuccess()
        {
            // Arrange
            var user = new ApplicationUser
            {
                UserName = "TestUser",
                Email = "test@example.com"
            };
            _userManagerMock.Setup(x => x.CreateAsync(user, "Password123!"))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authService.RegisterUserAsync(user, "Password123!");

            // Assert
            Assert.IsTrue(result.Succeeded);
        }

        [Test]
        public async Task ValidateUserCredentialsAsync_ValidCredentials_ReturnsTrue()
        {
            // Arrange
            var user = new ApplicationUser
            {
                UserName = "TestUser",
                Email = "test@example.com"
            };
            _userManagerMock.Setup(x => x.FindByNameAsync("TestUser"))
                .ReturnsAsync(user);
            _userManagerMock.Setup(x => x.CheckPasswordAsync(user, "Password123!"))
                .ReturnsAsync(true);

            // Act
            bool isValid = await _authService.ValidateUserCredentialsAsync("TestUser", "Password123!");

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}
