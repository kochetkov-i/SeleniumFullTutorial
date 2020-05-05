using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFullTutorial.Common;
using SeleniumFullTutorial.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumFullTutorial.Helpers
{
    public class SortHelper : HelperBase
    {
        public SortHelper(ApplicationManager manager) : base(manager) { }

        private IWebElement[] GetCountriesElements()
        {
            return driver.FindElements(By.CssSelector(".row")).ToArray();
        }

        public void CheckZones(List<CountryData> countryDatas, int count)
        {
            countryDatas.ForEach(c =>
            {
                manager.Navigator.GoToCheckedlink(c.Link);
                if(TestContext.CurrentContext.Test.MethodName == "AZZonesSortTest")
                    Console.WriteLine($"Country {c.Name} with {c.Zones} Zones  are sorted: {IsAZSorted(GetGeoZones().ToArray(), count)}");
                else
                    Console.WriteLine($"Country {c.Name} with {c.Zones} Zones  are sorted: {IsAZSorted(GetZones().ToArray(), count)}");
            });
        }

        private List<string> GetZones()
        {
            List<string> result = new List<string>();
            var elements = driver.FindElements(By.CssSelector("input[name$='[name]']"));
            foreach(IWebElement el in elements)
            {
                result.Add(el.GetAttribute("value"));
            }
            return result;
        }

        private List<string> GetGeoZones()
        {
            List<string> result = new List<string>();
            var elements = driver.FindElements(By.CssSelector("select[name$='[zone_code]']>option[selected]"));
            foreach (IWebElement el in elements)
            {
                result.Add(el.GetAttribute("textContent"));
            }
            return result;
        }

        public (List<string>, List<CountryData>) GetCountiesLists()
        {
            return ConvertToCountryData(GetCountriesElements());
        }

        private (List<string>, List<CountryData>) ConvertToCountryData(IWebElement[] webs)
        {
            List<string> all = new List<string>();
            List<CountryData> zonesNeedCheck = new List<CountryData>();
            foreach (IWebElement w in webs)
            {
                var el = w.FindElement(By.CssSelector("a"));
                var elementForcCellIndex = driver.FindElements(By.CssSelector(".header th")).FirstOrDefault(x => x.GetAttribute("outerText") == "Zones");
                var zonesEl = w.FindElements(By.CssSelector("td")).FirstOrDefault(e => e.GetAttribute("cellIndex") == elementForcCellIndex.GetAttribute("cellIndex"));
                
                all.Add(el.GetAttribute("outerText"));
                if (Int32.Parse(zonesEl.GetAttribute("textContent")) > 1)
                {
                    var data = new CountryData(el.GetAttribute("outerText"), el.GetAttribute("href"), Int32.Parse(zonesEl.GetAttribute("textContent")));
                    zonesNeedCheck.Add(data);
                }  
            }
            return (all, zonesNeedCheck);
        }

        public bool IsAZSorted(string[] arr, int count)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (needToReOrder(arr[j], arr[j + 1], count)) return false;
                }
            }
            return true;
        }

        private bool needToReOrder(string s1, string s2, int count)
        {
            if (count <= 0) count = (s1.Length > s2.Length ? s2.Length : s1.Length);
            for (int i = 0; i < count; i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i])
                    return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i])
                {
                    Console.WriteLine($"{s1.ToCharArray()[i]} in {s1} > {s2.ToCharArray()[i]} in {s2}");
                    return true;
                }
            }
            return false;
        }
    }
}
