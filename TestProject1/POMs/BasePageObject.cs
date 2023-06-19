using OpenQA.Selenium;
using Serilog;

namespace TestProject1.POMs
{
    public abstract class BasePageObject
    {
        protected IWebDriver driver;
        protected ILogger logger;

        public BasePageObject(IWebDriver driver, ILogger logger)
        {
            this.driver = driver;
            this.logger = logger;
        }

        public void TakeScreenShot(string fileName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            logger.Debug($"Saving screenshot to {fileName}.PNG");
            ss.SaveAsFile($"{fileName}.PNG", ScreenshotImageFormat.Png);
        }
    }
}
