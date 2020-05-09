using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using SeleniumFullTutorial.Model;
using System.Linq;

namespace SeleniumFullTutorial.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            if (IsLoggedIn()) Logout();
            if(driver.Url.Contains("admin"))
                Type(By.Name("username"), account.Username);
            else
                Type(By.Name("email"), account.Username);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.Name("login")).Click();
        }

        public bool IsLoggedIn()
        {
            IWebElement element = GetLogoutElement();
            if (element != null)
                return element.Displayed;
            return false;
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                GetLogoutElement().Click();
            }
        }

        private IWebElement GetLogoutElement()
        {
            return driver.FindElements(By.CssSelector("a")).FirstOrDefault(el => el.GetProperty("title") == "Logout" || el.GetProperty("textContent") == "Logout");
        }
    }
}
