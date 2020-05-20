using NUnit.Framework;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class CheckLogsTests : AuthTestBase
    {
        [Test]
        public void CheckLogsProductTest()
        {
            app.Navigator.GoToAdminProductCategoryPage();
            app.CheckLogs.FindAnyLog();
        }
    }
}
