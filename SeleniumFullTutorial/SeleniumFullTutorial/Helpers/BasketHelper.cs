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
            manager.HomePage.FirstProduct.Click();
            SelectDropdownIfPresent();
            manager.ProductPage.AddProduct.Click();
            wait.Until(d => Int32.Parse(manager.HomePage.Quantity.GetAttribute("textContent")) != quantity);
        }

        private void SelectDropdownIfPresent()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse("0");
                manager.ProductPage.DropDownSelect(manager.ProductPage.SetSize);
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
            return Int32.Parse(manager.HomePage.Quantity.GetAttribute("textContent"));
        }

        public void Clean()
        {
            manager.CheckoutPage.Open();
            int count = manager.CheckoutPage.OrderSummary.Count;
            while (count != 0)
            {
                try
                {
                    
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse("0");
                    Retry.Do(() => { manager.CheckoutPage.RemoveButton.Click(); }, TimeSpan.FromSeconds(1));
                    wait.Until(d => manager.CheckoutPage.OrderSummary.Count != count);
                    count = manager.CheckoutPage.OrderSummary.Count;
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse(manager.Config["Timeouts:default"]);
                }
            }
        }
    }
}
