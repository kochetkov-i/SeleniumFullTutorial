using Microsoft.Extensions.Configuration;

namespace SeleniumFullTutorial.Common
{
    public class Configuration
    {
        public static IConfiguration Load()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
        }
    }
}
