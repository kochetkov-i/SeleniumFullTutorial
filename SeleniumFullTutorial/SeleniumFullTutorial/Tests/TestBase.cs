using NUnit.Framework;
using SeleniumFullTutorial.Common;

namespace SeleniumFullTutorial.Tests
{
    public class TestBase
    {
        protected ApplicationManager app;

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
    }
}
