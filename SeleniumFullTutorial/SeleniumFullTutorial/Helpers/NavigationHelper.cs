using SeleniumFullTutorial.Common;

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
    }
}
