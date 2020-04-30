using NUnit.Framework;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class ClickerTests : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Navigator.GoToAdminPage();
            app.Auth.Login(new AccountData("admin", "admin"));
        }

        [Test]
        public void ClickerTest()
        {
            var hrefs = app.Clicker.GetMainLinks();
            app.Clicker.ClickOnLinks(hrefs);
        }
    }
}
