using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using Serilog;
using OpenQA.Selenium.Chrome;
using Serilog.Core;
using System;
using System.Threading;
using TestProject1.POMs;

namespace TestProject1
{
    [TestClass]
    public class FunctionalTestOne
    {
        private static IWebDriver driver;
        private static ILogger logger;


        [ClassInitialize]
        public static void SetupClass(TestContext _)
        {
            //Session.ClassInitialize(testContext);
            driver = Session.Driver;
            logger = Session.Log;
            driver.Manage().Window.Maximize();
            logger.Information("Starting test");
        }

        public static void NavigateToUrl(IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

       
        [TestMethod]
        public void TestLoginValidUser()
        {
            #region arrange
            LoginPage loginPage = new LoginPage(driver, logger);
            #endregion
            #region act
            loginPage.LogIn("standard_user", "secret_sauce");
            #endregion
            #region assert
            Assert.IsTrue(loginPage.IsLoggedIn());
            #endregion
        }

        [ClassCleanup]
        public static void TearDownClass()
        {
            logger.Information("End Test");
            
        }
    }
}
