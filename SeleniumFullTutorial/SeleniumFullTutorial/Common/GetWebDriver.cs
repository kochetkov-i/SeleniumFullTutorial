﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SeleniumFullTutorial.Common
{
    public class GetWebDriver
    {
        private static IWebDriver Driver;
        public static IWebDriver Do(string browser)
        {
            var config = Configuration.Load();
            try
            {
                switch (browser)
                {
                    case "chrome":
                        Driver = new ChromeDriver(SetDriverOptions.Do(new ChromeOptions()));
                        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse(config["Timeouts:default"]);
                        Driver.Manage().Timeouts().PageLoad = TimeSpan.Parse(config["Timeouts:default"]);
                        Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.Parse(config["Timeouts:default"]);
                        return Driver;
                    case "firefox":
                        return new FirefoxDriver(SetDriverOptions.Do(new FirefoxOptions()));
                    default:
                        throw new ArgumentException($"Unknown browser type: {browser}");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Can not start selenium", ex);
            }
        }
    }
}
