using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.ObjectModel;

namespace SeleniumFullTutorial.Common
{
    public class GetWebDriver
    {
        private static EventFiringWebDriver Driver;
        public static EventFiringWebDriver Do(string browser)
        {
            var config = Configuration.Load();
            try
            {
                switch (browser)
                {
                    case "chrome":
                        Driver = new EventFiringWebDriver(new ChromeDriver(SetDriverOptions.Do(new ChromeOptions())));

                        Driver.FindingElement += (sender, e) => Console.WriteLine(e.FindMethod);
                        Driver.FindElementCompleted += (sender, e) => Console.WriteLine(e.FindMethod + " found");
                        Driver.ExceptionThrown += (sender, e) => Console.WriteLine(e.ThrownException);

                        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Parse(config["Timeouts:default"]);
                        Driver.Manage().Timeouts().PageLoad = TimeSpan.Parse(config["Timeouts:default"]);
                        Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.Parse(config["Timeouts:default"]);

                        return Driver;
                    case "firefox":
                        return new EventFiringWebDriver(new FirefoxDriver(SetDriverOptions.Do(new FirefoxOptions())));
                    case "cloud_chrome":
                        DesiredCapabilities capabilities = new DesiredCapabilities();
                        capabilities.SetCapability("os", "Windows");
                        capabilities.SetCapability("os_version", "10");
                        capabilities.SetCapability("browser", "Chrome");
                        capabilities.SetCapability("browser_version", "81");
                        capabilities.SetCapability("name", "ilyakochetkov1's First Test");
                        string URL = "https://" + config["userInfo:USERNAME"] + ":" + config["userInfo:AUTOMATE_KEY"] + "@hub-cloud.browserstack.com/wd/hub";
                        Driver = new EventFiringWebDriver(new RemoteWebDriver(new Uri(URL), capabilities));
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
