﻿using NUnit.Framework;
using SeleniumFullTutorial.Model;

namespace SeleniumFullTutorial.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void AdminLoginTest()
        {
            app.Navigator.GoToAdminPage();
            app.Auth.Login(new AccountData("admin", "admin"));
        }
    }
}
