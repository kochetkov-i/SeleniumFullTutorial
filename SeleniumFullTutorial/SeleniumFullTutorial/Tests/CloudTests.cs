using NUnit.Framework;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class CloudTests : TestBase
    {
        [Test]
        public void IXBTClickTest()
        {
            app.Clicker.ClickOnNews();
        }
    }
}
