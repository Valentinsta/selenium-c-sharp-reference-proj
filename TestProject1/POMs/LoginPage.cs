using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject1.POMs
{
    public class LoginPage : BasePageObject
    {
        public const string baseUrl = "https://www.saucedemo.com";

        public LoginPage(IWebDriver driver, ILogger logger) : base(driver, logger)
        {

        }

        public void LogIn(string username, string password)
        {
            driver.Navigate().GoToUrl($"{baseUrl}/");
            logger.Information("Navigating to login page");
            IWebElement userInput = driver.FindElement(By.Id("user-name"));
            logger.Information("Sending keys to username input");
            userInput.SendKeys(username);

            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            logger.Information("Sending keys to password");
            passwordInput.SendKeys(password);

            IWebElement loginButton = driver.FindElement(By.Id("login-button"));
            logger.Information("Clicking login button");
            loginButton.Click();
        }

        public bool IsLoggedIn()
        {
            IWebElement userInput;
            try
            {
                userInput = driver.FindElement(By.Id("react-burger-menu-btn"));
                logger.Information("User is logged in");
                return true;
            }
            catch (NoSuchElementException)
            {
                logger.Information("User is not logged in");
                return false;
            }
        }
    }
}
