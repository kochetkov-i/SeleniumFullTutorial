using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumFullTutorial.Common
{
    public class GetWebDriver
    {
        public static IWebDriver Do(string browser)
        {
            try
            {
                switch (browser)
                {
                    case "chrome":
                        return new ChromeDriver(SetDriverOptions.Do(new ChromeOptions()));
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
