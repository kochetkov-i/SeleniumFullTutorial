using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Helpers
{
    public class ProductHelper : HelperBase
    {
        public ProductHelper(ApplicationManager manager) : base(manager) { }

        public ProductStyleData GetOuterProductStyle()
        {
            ProductStyleData outer = new ProductStyleData();

            IWebElement firstProduct = driver.FindElement(By.CssSelector("#box-campaigns li"));
            outer.Name = firstProduct.FindElement(By.CssSelector(".name")).GetAttribute("textContent");
            outer = FillPriceValues(outer, firstProduct);

            string link = firstProduct.FindElement(By.CssSelector("a")).GetAttribute("href");
            manager.Navigator.GoToCheckedlink(link);

            return outer;
        }

        public ProductStyleData GetInnerProductStyle()
        {
            ProductStyleData inner = new ProductStyleData();

            IWebElement firstProduct = driver.FindElement(By.CssSelector("#box-product"));
            inner.Name = firstProduct.FindElement(By.CssSelector(".title")).GetAttribute("textContent");
            inner = FillPriceValues(inner, firstProduct);

            return inner;
        }

        private ProductStyleData FillPriceValues(ProductStyleData data, IWebElement element)
        {
            data.RegularPrice = element.FindElement(By.CssSelector(".regular-price")).GetAttribute("textContent");
            data.RegularPriceColor = element.FindElement(By.CssSelector(".regular-price")).GetCssValue("color");
            data.RegularPriceTextSize = element.FindElement(By.CssSelector(".regular-price")).GetCssValue("font-size");
            data.RegularPriceTextStyle = element.FindElement(By.CssSelector(".regular-price")).GetCssValue("text-decoration-line");
            data.RegularPriceTextFront = element.FindElement(By.CssSelector(".regular-price")).GetCssValue("font-weight");

            data.CampaignPrice = element.FindElement(By.CssSelector(".campaign-price")).GetAttribute("textContent");
            data.CampaignPriceColor = element.FindElement(By.CssSelector(".campaign-price")).GetCssValue("color");
            data.CampaignPriceTextSize = element.FindElement(By.CssSelector(".campaign-price")).GetCssValue("font-size");
            data.CampaignPriceTextStyle = element.FindElement(By.CssSelector(".campaign-price")).GetCssValue("text-decoration-line");
            data.CampaignPriceTextFront = element.FindElement(By.CssSelector(".campaign-price")).GetCssValue("font-weight");

            return data;
        }

    }
}
