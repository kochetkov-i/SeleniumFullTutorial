using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumFullTutorial.Common
{
    public class TestBase
    {
        public static IWebDriver Driver;
        public static WebDriverWait Wait;

        [SetUp]
        public static void StartBrowser()
        {
            try
            {
                Driver = new ChromeDriver();
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Can not start selenium", ex);
            }
        }

        [TearDown]
        public static void TearDown()
        {
            Driver.Quit();
        }
    }
}
