using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using SeleniumFullTutorial.Helpers;
using SeleniumFullTutorial.Pages;
using System;
using System.Threading;

namespace SeleniumFullTutorial.Common
{
    public class ApplicationManager
    {
        protected EventFiringWebDriver driver;
        protected WebDriverWait wait;
        protected IConfiguration config;
        protected string baseURL;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected ClickerHelper clickerHelper;
        protected CheckElementsHelper checkElementsHelper;
        protected SortHelper sortHelper;
        protected ProductHelper productHelper;
        protected CreateUsersHelper createUsersHelper;
        protected AddProductHelper addProductHelper;
        protected BasketHelper basketHelper;
        protected NewWindowHelper newWindowHelper;
        protected CheckLogHelper checkLogHelper;

        protected HomePage homePage;
        protected CheckoutPage checkoutPage;
        protected ProductPage productPage;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            config = Configuration.Load();
            driver = GetWebDriver.Do(config["appSettings:browser"]);
            wait = new WebDriverWait(driver, TimeSpan.Parse(config["Timeouts:default"]));
            baseURL = config["appSettings:baseUrl"];

            loginHelper = new LoginHelper(this);
            clickerHelper = new ClickerHelper(this);
            checkElementsHelper = new CheckElementsHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            sortHelper = new SortHelper(this);
            productHelper = new ProductHelper(this);
            createUsersHelper = new CreateUsersHelper(this);
            addProductHelper = new AddProductHelper(this);
            basketHelper = new BasketHelper(this);
            newWindowHelper = new NewWindowHelper(this);
            checkLogHelper = new CheckLogHelper(this);

            homePage = new HomePage(driver, this);
            checkoutPage = new CheckoutPage(driver, this);
            productPage = new ProductPage(driver, this);
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

        public EventFiringWebDriver Driver => driver;
        public NavigationHelper Navigator => navigator;
        public WebDriverWait Wait => wait;
        public IConfiguration Config => config;
        public LoginHelper Auth => loginHelper;
        public ClickerHelper Clicker => clickerHelper;
        public CheckElementsHelper CheckEl => checkElementsHelper;
        public SortHelper Sort => sortHelper;
        public ProductHelper Product => productHelper;
        public CreateUsersHelper User => createUsersHelper;
        public AddProductHelper AddProduct => addProductHelper;
        public BasketHelper Basket => basketHelper;
        public NewWindowHelper Window => newWindowHelper;
        public CheckLogHelper CheckLogs => checkLogHelper;
        public HomePage HomePage => homePage;
        public CheckoutPage CheckoutPage => checkoutPage;
        public ProductPage ProductPage => productPage;
    }
}
