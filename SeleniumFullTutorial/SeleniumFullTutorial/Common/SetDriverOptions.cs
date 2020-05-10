using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace SeleniumFullTutorial.Common
{
    public class SetDriverOptions
    {
        public static ChromeOptions Do(ChromeOptions option)
        {
            //Из конфигурации добавляем все аргументы из секции ChromeOptionsArguments
            var config = Configuration.Load();
            config.GetSection("ChromeOptionsArguments").Get<List<string>>().ForEach(arg => option.AddArgument(arg));
            //Из конфига получаем AdditionalCapability
            foreach (var section in config.GetSection("ChromeAdditionalCapability").GetChildren())
            {
                bool result;
                var values = section.Get<string[]>();
                //Если удалось распарсить True/False то 
                //второе значение всегда либо True/False т.к. определяет глобальный параметр или нет
                if (bool.TryParse(values[0], out result))
                    option.AddAdditionalCapability(section.Key, result, bool.Parse(values[1]));
                //Если значение отличается от True/False
                else
                    option.AddAdditionalCapability(section.Key, values[0], bool.Parse(values[1]));
            }
            option.PageLoadStrategy = PageLoadStrategy.Normal;
            return option;
        }

        public static FirefoxOptions Do(FirefoxOptions option)
        {
            return option;
        }
    }
}
