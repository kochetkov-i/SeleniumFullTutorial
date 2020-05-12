using NUnit.Framework;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class NewWindowTests : AuthTestBase
    {
        [Test]
        public void OpenNewWindowTest()
        {
            app.Navigator.GoToAdminCountriesPage();
            app.Window.OpenNewCountryCreate();
            app.Window.OpenAllNewWindows();
        }
    }
}
