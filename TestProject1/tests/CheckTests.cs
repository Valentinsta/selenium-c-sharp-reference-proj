using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using Serilog;


namespace TestProject1
{
	[TestClass]
	public class CheckTests
	{
		protected static ILogger logger;

        [ClassInitialize]
		public static void SetupClass(TestContext context)
		{
            logger = Session.Log;

            Session.Log.Information("[C] : Before each class");
            logger.Information("[C] : Before each class");
		}

		[ClassCleanup]
		public static void TeardDownClas()
		{
            logger.Information("[C] : After each class");
		}

		[TestInitialize]
		public void TestInitialize()
        {
            logger.Information("[T] : Before each test");
        }

		[TestCleanup]
		public void TestCleanup()
		{
            logger.Information("[T] : After each test");
		}

		[TestMethod]
		public void CheckAlwaysPasses()
		{
            logger.Information("TestMethod");
            Assert.IsTrue(true);
		}
	}
}