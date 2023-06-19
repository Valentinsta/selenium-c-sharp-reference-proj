using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestProject1.tests
{
    [TestClass]
    public class DataRowsTests
    {
        private static int _testCount = 0;
        private static readonly System.Timers.Timer _timer = new System.Timers.Timer(1000);
        private static DateTime _currentTime;
        private static CustomLogger logger = new CustomLogger();
        
        [TestInitialize]
        public void TestInitialize()
        {
            // This method runs before each test
            // Code for setting up each test
            _testCount++;
            logger.LogInformation($"Start test {_testCount}");
            var remainder = _testCount % 10;
            if (remainder == 1)
            {
                logger.LogInformation($"Started counting @ {(DateTime.Now).Ticks}");
                _currentTime = DateTime.Now;
            }
            else if (remainder == 0)
            {
                logger.LogInformation($"Started timer @ {(DateTime.Now).Ticks}");
                _timer.Start();
            }

        }
        [TestCleanup]
        public void TestCleanup()
        {
            // This method runs before each test
            // Code for setting up each test
            if (_testCount % 10 == 0)
            {
                _timer.Stop();
                logger.LogInformation($"Ended timer @ {(DateTime.Now).Ticks}");
                var elapsedTime = (DateTime.Now - _currentTime).TotalMilliseconds;
                int limit = 100;
                if (elapsedTime < limit)
                {
                    logger.LogInformation($"Sleeping for  {limit - (int)elapsedTime}");
                    Thread.Sleep(limit - (int)elapsedTime);
                }
            }
            logger.LogInformation($"End test {_testCount}");
        }

        [DataRow(0, 1)]
        [DataRow(1, 2)]
        [DataRow(2, 3)]
        [DataRow(3, 4)]
        [DataRow(4, 5)]
        [DataRow(5, 6)]
        [DataRow(6, 7)]
        [DataRow(7, 8)]
        [DataRow(8, 9)]
        [DataRow(9, 10)]
        [DataRow(10, 11)]
        [DataRow(11, 12)]
        [DataRow(12, 13)]
        [DataRow(13, 14)]
        [DataRow(14, 15)]
        [DataRow(15, 16)]
        [DataRow(16, 17)]
        [DataRow(17, 18)]
        [DataRow(18, 19)]
        [DataRow(19, 20)]
        [DataRow(20, 21)]
        [DataRow(21, 22)]
        [DataRow(31, 22)]
        [DataTestMethod]
        public void GivenDataIsEqualToResultMinusOne(int number, int result)
        {
            var actual = number + 1;
            actual.Should().Be(result);
            logger.LogInformation($"DataTestMethod {number} {result}");
        }
    }
}
