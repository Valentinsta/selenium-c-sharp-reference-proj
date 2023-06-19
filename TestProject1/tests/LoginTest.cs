using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using FluentAssertions;
using Serilog;
using FluentAssertions.Execution;
using TestProject1.POMs;

namespace TestProject1
{
    [TestClass]
    public class LoginTest
    {
        private static IWebDriver driver;
        private static ILogger logger;
        private static string invalid_user = "invalid_user";
        private static string valid_password = "valid_password";

        [ClassInitialize]
        public static void SetupClass(TestContext testContext)
        {
            driver = Session.Driver;
            logger = Session.Log;
            invalid_user = "invalid_user";
            valid_password = "valid_password";
            logger.Warning("ClassInitialize");
        }

        [ClassCleanup]
        public static void ClassTearDown()
        {
            logger.Warning("ClassCleanup");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            logger.Warning("TestInitialize");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            logger.Warning("TestCleanup");
        }

        [TestMethod]
        public void TestLoginInvalidUser()
        {
            #region arrange
            //string expectedMessage = "Expected message";
            LoginPage loginPage = new LoginPage(driver, logger);
            #endregion
            #region act
            loginPage.LogIn(invalid_user, valid_password);
            //string actualMessage = "";
            #endregion
            #region assert
            using (new AssertionScope())
            {
                loginPage.IsLoggedIn().Should().BeTrue();
                //Assert.AreEqual(expectedMessage, actualMessage);
            }
            #endregion
        }
    }
}
