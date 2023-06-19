using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject1.POMs;

namespace TestProject1
{
    public class Pages
    {
        private readonly IWebDriver _driver;
        private readonly ILogger _logger;
        public Pages(IWebDriver driver, ILogger logger)
        {
            _driver = driver;
            _logger = logger;
        }

        public LoginPage LoginPage => new LoginPage(_driver, _logger);
        public ProductsPage ProductsPage { get; set; }
        public CartPage CartPage { get; set; }
        public CheckoutPage CheckoutPage { get; set; }
        public CheckoutOverviewPage CheckoutOverviewPage { get; set; }
        public CheckoutCompletePage CheckoutCompletePage { get; set; }
    }
}
