using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumFullTutorial.Common;

namespace SeleniumFullTutorial.Pages
{
    public class ProductPage : BasePage
    {
        protected ApplicationManager manager;
        public ProductPage(IWebDriver driver, ApplicationManager manager) : base(driver)
        {
            this.manager = manager;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "button[name='add_cart_product']")]
        public IWebElement AddProduct;

        [FindsBy(How = How.Name, Using = "options[Size]")]
        public IWebElement SetSize;
    }
}
