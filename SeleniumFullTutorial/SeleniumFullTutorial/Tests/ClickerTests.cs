using NUnit.Framework;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class ClickerTests : AuthTestBase
    {
        [Test]
        public void ClickerTest()
        {
            var hrefs = app.Clicker.GetMainLinks();
            app.Clicker.ClickOnLinks(hrefs);
        }
    }
}
