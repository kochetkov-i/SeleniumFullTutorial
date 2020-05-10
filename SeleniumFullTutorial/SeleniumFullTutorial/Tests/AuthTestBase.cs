using NUnit.Framework;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Navigator.GoToAdminPage();
            app.Auth.Login(new AccountData("admin", "admin"));
        }
    }
}
