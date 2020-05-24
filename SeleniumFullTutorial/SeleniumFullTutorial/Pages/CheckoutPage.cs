using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumFullTutorial.Common;
using System.Collections.Generic;

namespace SeleniumFullTutorial.Pages
{
    public class CheckoutPage : BasePage
    {
        protected ApplicationManager manager;
        public CheckoutPage(IWebDriver driver, ApplicationManager manager) : base(driver)
        {
            this.manager = manager;
            PageFactory.InitElements(driver, this);
        }

        public void Open()
        {
            manager.Navigator.GoToCheckoutPage();
        }

        [FindsBy(How = How.CssSelector, Using = "td.item")]
        public IList<IWebElement> OrderSummary;

        [FindsBy(How = How.Name, Using = "remove_cart_item")]
        public IWebElement RemoveButton;
    }
}
