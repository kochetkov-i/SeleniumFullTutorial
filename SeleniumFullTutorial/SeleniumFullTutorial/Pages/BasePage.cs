using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumFullTutorial.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void DropDownSelect(IWebElement element)
        {
            try
            {
                wait.Until(d => element.Displayed);
                element.Click(); //без этого клика нельзя получить количество опций
                SelectElement menu = new SelectElement(element);
                menu.SelectByIndex(new Random().Next(1, menu.Options.Count));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Random DropDownSelect failed: {ex}");
            }
        }
    }
}
