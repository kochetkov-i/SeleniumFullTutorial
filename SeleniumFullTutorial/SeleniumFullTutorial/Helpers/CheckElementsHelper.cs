using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeleniumFullTutorial.Helpers
{
    public class CheckElementsHelper : HelperBase
    {
        public CheckElementsHelper(ApplicationManager manager) : base(manager) { }

        public List<IWebElement> FindAllProducts()
        {
            return driver.FindElements(By.CssSelector("[class^=product]")).ToList();
        }

        public bool IsElementContent(IWebElement l, By by)
        {
            var result = l.FindElements(by).Count;
            if (result == 1) return true;
            return false;
        }
    }
}
