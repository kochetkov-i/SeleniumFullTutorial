using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class CheckElements : TestBase
    {
        [Test]
        public void FindStickersTest()
        {
            var list = app.CheckEl.FindAllProducts();
            foreach(var l in list)
            {
                Assert.That(app.CheckEl.IsElementContent(l, By.CssSelector("[class^=sticker]")), "Stickers more o less one");
            }
        }
    }
}
