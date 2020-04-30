using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {

            //if (IsLoggedIn())
            //{
            //    if (IsLoggedIn(account))
            //    {
            //        return;
            //    }
            //    Logout();
            //}
            Type(By.Name("username"), account.Username);
            Type(By.Name("password"), account.Password);
            driver.FindElement(By.Name("login")).Click();
        }
    }
}
