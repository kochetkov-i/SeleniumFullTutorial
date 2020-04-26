using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumFullTutorial.Common
{
    public class TestBase
    {
        public static IWebDriver Driver;
        public static WebDriverWait Wait;
        public static IConfiguration Config;

        [SetUp]
        public static void StartBrowser()
        {
            Config = Configuration.Load();
            Driver = GetWebDriver.Do(Config["appSettings:browser"]);
            Wait = new WebDriverWait(Driver, TimeSpan.Parse(Config["Timeouts:default"]));
        }

        [TearDown]
        public static void TearDown()
        {
            Driver.Quit();
        }
    }
}
