using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using SeleniumFullTutorial.Model;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace SeleniumFullTutorial.Helpers
{
    public class AddProductHelper : HelperBase
    {
        public AddProductHelper(ApplicationManager manager) : base(manager) { }
        private string path = Path.Combine(Directory.GetCurrentDirectory(), "Resourses\\");

        public void CreateNewProduct(ProductData prodouct)
        {
            OpenNewProductForm();
            FillProductForm(prodouct);
            SaveProduct();
        }

        private void SaveProduct()
        {
            PressButton(By.CssSelector("button[name=save]"));
        }

        private void FillProductForm(ProductData prodouct)
        {
            MoveToTab("General");
            PressButton(By.CssSelector("[name='status'][value='1']"));
            Type(By.Name("name[en]"), prodouct.Name);
            Type(By.Name("code"), prodouct.Code);
            SelectCheckBox("categories[]", new string[] { "Rubber Ducks" });
            SelectCheckBox("product_groups[]");
            Type(By.Name("quantity"), prodouct.Quantity);
            driver.FindElement(By.Name("new_images[]")).SendKeys(path + prodouct.Images);
            SetDatepicker("date_valid_from", prodouct.DateValidFrom);
            SetDatepicker("date_valid_to", prodouct.DateValidTo);

            MoveToTab("Information");
            DropDownSelect(By.Name("manufacturer_id"), prodouct.Manufacturer);
            Type(By.Name("short_description[en]"), prodouct.ShortDescription);
            Type(By.CssSelector(".trumbowyg-editor"), prodouct.Description);

            MoveToTab("Prices");
            Type(By.Name("purchase_price"), prodouct.PurchasePrice);
            DropDownSelect(By.Name("purchase_price_currency_code"));
        }

        //Один из вариантов заполнения поля даты, после активации поля кликом ввод начинается с дней -> месяцы -> год
        // т.е. строка должна быть ДДММГГГГ однако после сохранения всего продукта не отображается
        // в режиме дебага работет 
        //private void SelectDate(By locator, string dateValidFrom)
        //{
        //    IWebElement element = driver.FindElement(locator);
        //    wait.Until(d => driver.FindElement(locator).Enabled);
        //    element.Click();
        //    element.SendKeys(dateValidFrom);
        //}

        //При заполнении корректно проставляет значения, однако в итоговом продукте даты не заполнены
        //иногда работает
        public void SetDatepicker(string name, string date)
        {
            IWebElement element = driver.FindElement(By.Name(name));
            wait.Until(d => element.Displayed);
            (driver as IJavaScriptExecutor).ExecuteScript($"arguments[0].setAttribute('value', '{date}');", element);
            Console.WriteLine($"{element.GetAttribute("value")} получаем значение поля {name} после записи");
            //Потеря фокуса с поля не особо помогает
            //element.SendKeys(Keys.Tab + Keys.Tab + Keys.Tab);
        }

        private void SelectCheckBox(string name, string[] values = null)
        {
            var selectedElements = driver.FindElements(By.CssSelector($"[type='checkbox'][name='{name}'][checked]"));
            if(selectedElements.Count > 0)
            {
                foreach (IWebElement el in selectedElements)
                {
                    el.Click();
                }
            }
            if(values == null || values.Length == 0)
            {
                driver.FindElements(By.CssSelector($"[type='checkbox'][name='{name}']"))[0].Click();
                return;
            }
            foreach(string s in values)
            {
                driver.FindElement(By.CssSelector($"[type='checkbox'][name='{name}'][data-name='{s}']")).Click();
            }
        }

        private void MoveToTab(string tab)
        {
            if (driver.FindElement(By.CssSelector(".tabs li.active")).GetAttribute("innerText") == tab)
                return;
            driver.FindElements(By.CssSelector(".tabs li")).FirstOrDefault(el => el.GetAttribute("innerText") == tab).Click();
            manager.Wait.Until(d => driver.FindElement(By.CssSelector(".tabs li.active")).GetAttribute("innerText") == tab);
        }

        private void OpenNewProductForm()
        {
            driver.FindElements(By.CssSelector(".button")).
                FirstOrDefault(el => el.GetAttribute("innerText") == " Add New Product").Click();
            manager.Wait.Until(d => driver.FindElement(By.CssSelector("h1")).GetAttribute("innerText") == " Add New Product");
            //без этой паузы почему что не находит елементы 
            Thread.Sleep(1000);
        }

        public bool ShowInList(string name)
        {
            manager.Wait.Until(d => driver.FindElement(By.CssSelector("h1")).GetAttribute("innerText") == " Catalog");
            return driver.FindElements(By.CssSelector(".row")).FirstOrDefault(el => el.GetAttribute("innerText").Contains(name)).Displayed;
        }
    }
}
