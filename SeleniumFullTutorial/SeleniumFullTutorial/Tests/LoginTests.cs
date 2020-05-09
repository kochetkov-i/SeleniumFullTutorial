using NUnit.Framework;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void AdminLoginTest()
        {
            app.Navigator.GoToAdminPage();
            app.Auth.Login(new AccountData("admin", "admin"));
        }

        [Test]
        public void NewUserLoginTest()
        {
            AccountData user = new AccountData()
            {
                FirstName = GenerateRandomString(10),
                LastName = GenerateRandomString(20),
                Address = GenerateRandomString(40),
                Postcode = GenerateRandomString(5, true),
                City = GenerateRandomString(10),
                Country = "United States",
                Email = app.User.GetEmailFormat(GenerateRandomString(5)),
                Phone = GenerateRandomString(11, true),
                Password = GenerateRandomString(2),
            };
            user.Username = user.Email;

            app.User.RegistrNewUser(user);
            app.Auth.Login(user);
            app.Auth.Logout();
        }
    }
}
