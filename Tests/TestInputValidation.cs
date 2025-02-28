using NUnit.Framework;
using SafeVault.Web.Helpers;

namespace SafeVault.Tests
{
    [TestFixture]
    public class TestInputValidation
    {
        [Test]
        public void ValidInput_ReturnsTrue()
        {
            // Test with alphanumeric input
            string input = "User123";
            bool result = ValidationHelpers.IsValidInput(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void InvalidInput_ReturnsFalse()
        {
            // Test input with disallowed special characters
            string input = "User<script>";
            bool result = ValidationHelpers.IsValidInput(input);
            Assert.IsFalse(result);
        }

        [Test]
        public void SQLInjectionAttempt_ReturnsFalse()
        {
            // Simulate a SQL injection input
            string input = "test'; DROP TABLE Users; --";
            bool result = ValidationHelpers.IsValidInput(input);
            Assert.IsFalse(result);
        }

        [Test]
        public void XSSAttempt_ReturnsFalse()
        {
            // Basic XSS test - this function doesn't filter HTML tags by default,
            // so you could extend it if necessary.
            string input = "<script>alert('XSS');</script>";
            bool result = ValidationHelpers.IsValidInput(input);
            Assert.IsFalse(result);
        }
    }
}
