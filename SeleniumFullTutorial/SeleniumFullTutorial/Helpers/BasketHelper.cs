using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using System;

namespace SeleniumFullTutorial.Helpers
{
    public class BasketHelper : HelperBase
    {
        public BasketHelper(ApplicationManager manager) : base(manager) { }

        public void AddFirstProduct(int quantity)
        {
            PressButton(By.CssSelector("li.product"));
            SelectDropdownIfPresent(By.Name("options[Size]"));
            PressButton(By.CssSelector("button[name='add_cart_product']"));
            wait.Until(d => Int32.Parse(d.FindElement(By.CssSelector(".quantity")).GetAttribute("textContent")) != quantity);
        }

        private void SelectDropdownIfPresent(By locator)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse("0");
                driver.FindElement(locator);
                DropDownSelect(locator);
            }
            catch(Exception)
            {

            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse(manager.Config["Timeouts:default"]);
            }
        }

        public int GetQuantity()
        {
            return Int32.Parse(driver.FindElement(By.CssSelector(".quantity")).GetAttribute("textContent"));
        }

        public void Clean()
        {
            manager.Navigator.GoToCheckoutPage();
            int count = driver.FindElements(By.CssSelector("td.item")).Count;
            while (count != 0)
            {
                try
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse("0");
                    Retry.Do(() => { PressButton(By.Name("remove_cart_item")); }, TimeSpan.FromSeconds(1));
                    wait.Until(d => driver.FindElements(By.CssSelector("td.item")).Count != count);
                    count = driver.FindElements(By.CssSelector("td.item")).Count;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse(manager.Config["Timeouts:default"]);
                }
            }
        }
    }
}
