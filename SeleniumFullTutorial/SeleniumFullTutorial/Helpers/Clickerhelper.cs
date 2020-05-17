using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SeleniumFullTutorial.Helpers
{
    public class ClickerHelper : HelperBase
    {
        public ClickerHelper(ApplicationManager manager) : base(manager) { }

        public List<string> GetMainLinks()
        {
           return GetElementsLinks(driver.FindElements(By.CssSelector("li#app- a")));
        }

        public void ClickOnNews()
        {
            driver.FindElement(By.CssSelector("[data-menuitem='news']")).Click();
        }

        private List<string> GetElementsLinks(ReadOnlyCollection<IWebElement> elements)
        {
            List<string> result = new List<string>();
            foreach (var el in elements)
            {
                result.Add(el.GetAttribute("href"));
            }
            return result;
        }

        public void ClickOnLinks(List<string> hrefs)
        {
            hrefs.ForEach(h =>
            {
                manager.Navigator.GoToCheckedlink(h);
                if (IsElementPresent(By.CssSelector("h1")))
                    Console.WriteLine($"Header H1 was found in element:{driver.FindElement(By.CssSelector("h1")).Text}");
                var subhrefs = GetElementsLinks(driver.FindElements(By.CssSelector("ul.docs a")));
                subhrefs.ForEach(sh => {
                    manager.Navigator.GoToCheckedlink(sh);
                    if (IsElementPresent(By.CssSelector("h1")))
                        Console.WriteLine($"Sub_menu: Header H1 was found in element:{driver.FindElement(By.CssSelector("h1")).Text}");
                });
            });
        }
    }
}
