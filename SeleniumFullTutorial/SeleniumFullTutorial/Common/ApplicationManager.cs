﻿using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumFullTutorial.Helpers;
using System;
using System.Threading;

namespace SeleniumFullTutorial.Common
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected IConfiguration config;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected ClickerHelper clickerHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            config = Configuration.Load();
            driver = GetWebDriver.Do(config["appSettings:browser"]);
            wait = new WebDriverWait(driver, TimeSpan.Parse(config["Timeouts:default"]));
            baseURL = config["appSettings:baseUrl"];

            loginHelper = new LoginHelper(this);
            clickerHelper = new ClickerHelper(this);
            navigator = new NavigationHelper(this, baseURL);
        }

        //не всегда вызывается деструктор
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver => driver;
        public NavigationHelper Navigator => navigator;
        public WebDriverWait Wait => wait;
        public IConfiguration Config => config;
        public LoginHelper Auth => loginHelper;
        public ClickerHelper Clicker => clickerHelper;


    }
}