using NUnit.Framework;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class ProductsTests : TestBase
    {
        [Test]
        public void CampaignFirstProductTest()
        {
            ProductStyleData outerStyle = app.Product.GetOuterProductStyle();
            ProductStyleData innerStyle = app.Product.GetInnerProductStyle();

            Assert.IsTrue(outerStyle.IsValid());
            Assert.IsTrue(innerStyle.IsValid());
            Assert.IsTrue(outerStyle.Equals(innerStyle));
        }
    }
}
