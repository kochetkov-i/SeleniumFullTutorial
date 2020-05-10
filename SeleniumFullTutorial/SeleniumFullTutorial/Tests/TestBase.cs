using NUnit.Framework;
using SeleniumFullTutorial.Common;
using System;
using System.Globalization;
using System.Text;

namespace SeleniumFullTutorial.Tests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static Random rnd = new Random();

        [SetUp]
        public void StartBrowser()
        {
            app = ApplicationManager.GetInstance();
        }

        [TearDown]
        public void TearDown()
        {
            app.Stop();
        }

        public static string GenerateRandomString(int Length, bool isNumerical = false)
        {
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            if (isNumerical)
                Alphabet = "0123456789";
            StringBuilder sb = new StringBuilder(Length - 1);
            for (int i = 0; i < Length; i++)
            {
                sb.Append(Alphabet[rnd.Next(0, Alphabet.Length - 1)]);
            }
            return sb.ToString();
        }

        public static string GenerateRandomDate(string startDate = null)
        {
            string dateFormat = "yyyy-MM-dd";
            DateTime start = new DateTime();
            if (string.IsNullOrEmpty(startDate))
                start = DateTime.Now; 
            else
                start = DateTime.ParseExact(startDate, dateFormat, CultureInfo.CurrentCulture);
            DateTime end = new DateTime(2100,12,12);
            int count = (end - start).Days;
            return start.AddDays(rnd.Next(1, count)).ToString(dateFormat);
        }
    }
}
