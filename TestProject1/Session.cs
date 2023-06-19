using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using System;

namespace TestProject1
{
    [TestClass]
    public static class Session
    {
        //private static IWebDriver _driver;
        //private static IWebDriver _logger;
        public static ILogger Log { get; private set; }
        public static IWebDriver Driver { get; private set; }

        private static IWebDriver MakeChromedriver()
        {
            var options = new ChromeOptions();
            string pathToChromeDriver = Environment.GetEnvironmentVariable("CHROMEDRIVER_PATH");
            //options.AddArgument("headless");
            options.AddArgument("window-size=1920x1080");
            options.AddArgument("start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("no-default-browser-check");
            IWebDriver driver = new ChromeDriver(pathToChromeDriver, options);
            driver.Manage().Cookies.DeleteAllCookies();
            return driver;
        }


        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            // This method runs once before all tests in the assembly
            // Code for setting up the assembly for tests
            Driver = MakeChromedriver();
            Log = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

            Log.Warning("AssemblyInitialize");
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            Log.Information(@"Session.ClassInitialize");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // This method runs once before all tests in the class
            // Code for setting up the class for tests
            Log.Information(@"Session.ClassCleanup");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            try
            {
                // This method runs once after all tests in the assembly have run
                // Code for cleaning up after all tests in the assembly have run
                Log.Warning("AssemblyCleanup");
                if (Driver != null)
                {
                    Driver.Close();
                    Driver.Quit();
                    Log.Information("Quit driver");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in AssemblyCleanup");
            }
        }
    }
}