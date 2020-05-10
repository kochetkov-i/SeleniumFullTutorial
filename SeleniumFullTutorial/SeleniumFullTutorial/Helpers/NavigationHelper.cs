using SeleniumFullTutorial.Common;
using System;

namespace SeleniumFullTutorial.Helpers
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "litecart/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "litecart/");
        }

        public void GoToCheckedlink(string link)
        {
            if (driver.Url == link)
            {
                return;
            }
            driver.Navigate().GoToUrl(link);
        }

        public void GoToAdminPage()
        {
            GoToCheckedlink(baseURL + "litecart/admin/");
        }

        public void GoToAdminCountriesPage()
        {
            GoToCheckedlink(baseURL + "litecart/admin/?app=countries");
        }

        public void GoToAdminZonesPage()
        {
            GoToCheckedlink(baseURL + "litecart/admin/?app=geo_zones");
        }

        public void GoToCreateAccountPage()
        {
            GoToCheckedlink(baseURL + "litecart/en/create_account");
        }

        public void GoToAdminCatalogPage()
        {
            GoToCheckedlink(baseURL + "litecart/admin/?app=catalog");
        }

        public void GoToCheckoutPage()
        {
            GoToCheckedlink(baseURL + "litecart/checkout");
        }
    }
}
