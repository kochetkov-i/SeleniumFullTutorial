using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumFullTutorial.Helpers
{
    public class NewWindowHelper : HelperBase
    {
        public NewWindowHelper(ApplicationManager manager) : base(manager) { }

        public void OpenNewCountryCreate()
        {
            driver.FindElements(By.CssSelector(".button"))
                .FirstOrDefault(el => el.GetAttribute("text").Trim() == "Add New Country").Click();
        }

        public void OpenAllNewWindows()
        {
            By locator = By.CssSelector("form [target='_blank']");
            wait.Until(d => d.FindElements(locator).Count > 0);
            string mainWindow = driver.CurrentWindowHandle;
            ICollection<string> oldWindows = driver.WindowHandles;
            foreach (IWebElement element in driver.FindElements(locator))
            {
                element.Click();
                string newWindow = wait.Until(ThereIsWindowOtherThan(oldWindows));
                driver.SwitchTo().Window(newWindow);
                driver.Close();
                driver.SwitchTo().Window(mainWindow);
            }
        }

        private Func<IWebDriver, string> ThereIsWindowOtherThan(ICollection<string> oldWindows)
        {
            foreach(string nw in driver.WindowHandles)
            {
                if (!oldWindows.Contains(nw)) return (driver) => nw;
            }
            throw new ArgumentException("Нет новых окон");
        }
    }
}
