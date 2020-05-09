using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Helpers
{
    public class CreateUsersHelper : HelperBase
    {
        public CreateUsersHelper(ApplicationManager manager) : base(manager) { }

        public void RegistrNewUser(AccountData account)
        {
            manager.Navigator.GoToCreateAccountPage();
            FillAccountData(account);
            PressButtonCreate();
        }

        private void FillAccountData(AccountData account)
        {
            Type(By.Name("firstname"), account.FirstName);
            Type(By.Name("lastname"), account.LastName);
            Type(By.Name("address1"), account.Address);
            Type(By.Name("postcode"), account.Postcode);
            Type(By.Name("city"), account.City);
            Type(By.Name("email"), account.Email);
            Type(By.Name("phone"), account.Phone);
            Type(By.Name("password"), account.Password);
            Type(By.Name("confirmed_password"), account.Password);
            DropDownSelect(By.CssSelector("select[name=country_code]"), account.Country);
            DropDownSelect(By.CssSelector("select[name=zone_code]"));
        }

        public string GetEmailFormat(string v)
        {
            return $"{v}@{v}.com";
        }

        private void PressButtonCreate()
        {
            driver.FindElement(By.Name("create_account")).Click();
        }
    }
}
