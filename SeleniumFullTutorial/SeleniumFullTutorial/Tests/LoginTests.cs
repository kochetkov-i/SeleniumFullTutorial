using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void AdminLoginTest()
        {
            var account = new AccountData("admin", "admin");

            Driver.Url = "http://localhost/litecart/admin/";
            var element = Wait.Until(d => d.FindElement(By.Name("username")));
            element.SendKeys(account.Username);
            Driver.FindElement(By.Name("password")).SendKeys(account.Password);
            Driver.FindElement(By.Name("login")).Click();
        }   
    }
}
