using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumFullTutorial.Common;

namespace SeleniumFullTutorial.Pages
{
    public class HomePage : BasePage
    {
        protected ApplicationManager manager;
        public HomePage(IWebDriver driver, ApplicationManager manager) : base(driver)
        {
            this.manager = manager;
            PageFactory.InitElements(driver, this);
        }

        public void Open()
        {
            manager.Navigator.OpenHomePage();
        }

        [FindsBy(How = How.CssSelector, Using = ".quantity")]
        public IWebElement Quantity;

        [FindsBy(How = How.CssSelector, Using = "li.product")]
        public IWebElement FirstProduct;
    }
}
