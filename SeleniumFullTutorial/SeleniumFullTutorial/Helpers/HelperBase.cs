﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumFullTutorial.Common;
using System;

namespace SeleniumFullTutorial.Helpers
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            driver = manager.Driver;
            wait = manager.Wait;
            this.manager = manager;
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                wait.Until(d => d.FindElements(locator).Count > 0);
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public void PressButton(By locator)
        {
            try
            {
                wait.Until(d => d.FindElements(locator).Count > 0);
                driver.FindElement(locator).Click();
            }
            catch(Exception ex)
            {
                throw new TimeoutException($"Button {locator} not press: {ex}");
            }
        }

        public void DropDownSelect(By locator, string text)
        {
            if (text != null)
            {
                wait.Until(d => d.FindElements(locator).Count > 0);
                SelectElement menu = new SelectElement(driver.FindElement(locator));
                menu.SelectByText(text, true);
            }
        }

        public void DropDownSelect(By locator)
        {
            try
            {
                wait.Until(d => d.FindElements(locator).Count > 0);
                IWebElement element = driver.FindElement(locator);
                element.Click(); //без этого клика нельзя получить количество опций
                SelectElement menu = new SelectElement(element);
                menu.SelectByIndex(new Random().Next(1, menu.Options.Count));
            }
            catch(Exception ex)
            {
                throw new ApplicationException($"Random DropDownSelect failed: {ex}");
            }
        }
    }
}
