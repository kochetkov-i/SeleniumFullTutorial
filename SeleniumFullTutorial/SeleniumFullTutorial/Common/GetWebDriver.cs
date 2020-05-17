using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
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
                    case "cloud_chrome":
                        DesiredCapabilities capabilities = new DesiredCapabilities();
                        capabilities.SetCapability("os", "Windows");
                        capabilities.SetCapability("os_version", "10");
                        capabilities.SetCapability("browser", "Chrome");
                        capabilities.SetCapability("browser_version", "81");
                        capabilities.SetCapability("name", "ilyakochetkov1's First Test");
                        string URL = "https://" + config["userInfo:USERNAME"] + ":" + config["userInfo:AUTOMATE_KEY"] + "@hub-cloud.browserstack.com/wd/hub";
                        Driver = new RemoteWebDriver(new Uri(URL), capabilities);
                        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse(config["Timeouts:default"]);
                        Driver.Manage().Timeouts().PageLoad = TimeSpan.Parse(config["Timeouts:default"]);
                        return Driver;
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
