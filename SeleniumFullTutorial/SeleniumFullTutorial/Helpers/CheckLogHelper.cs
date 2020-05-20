using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumFullTutorial.Helpers
{
    public class CheckLogHelper : HelperBase
    {
        public CheckLogHelper(ApplicationManager manager) : base(manager) { }

        public void FindAnyLog()
        {
            GetProductList().ForEach(link => 
            {
                manager.Navigator.GoToCheckedlink(link);
                By locator = By.CssSelector("button[value='Cancel']");
                wait.Until(d => d.FindElements(locator).Count > 0);
                FindBrowserLogs();
                driver.FindElement(locator).Click();
            });

        }

        private void FindBrowserLogs()
        {
            try
            {
                var logs = driver.Manage().Logs.GetLog(LogType.Browser);
                // Вариант 2
                //var logs = driver.GetBrowserLogs();
                if (logs.Count() > 0)
                {
                    Console.WriteLine("Logs are detected");
                    foreach (LogEntry log in logs)
                        Console.WriteLine($"{log.Level}-{log.Timestamp}-{log.Message}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private List<string> GetProductList()
        {
            List<string> result = new List<string>();
            var elements = driver.FindElements(By.CssSelector("[href*='product_id'][title='Edit']"));
            foreach (IWebElement el in elements)
            {
                result.Add(el.GetAttribute("href"));
            }
            return result;
        }
    }
}
