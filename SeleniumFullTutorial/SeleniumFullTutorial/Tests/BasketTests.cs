using NUnit.Framework;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class BasketTests : TestBase
    {
        [Test]
        public void AddAndCleanBasketTest()
        {
            while(app.Basket.GetQuantity() < 3)
            {
                app.Basket.AddFirstProduct(app.Basket.GetQuantity());
                app.Navigator.OpenHomePage();
            }
            app.Basket.Clean();
        }
    }
}
