using OpenQA.Selenium;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace TestAutomationFramework.Core.Utilities
{
    public static class ScreenShotTaker
    {
        public static void TakeScreenShot(IWebDriver driver, string fileName, string screenshotDirectoryPath)
        {
            if (!Directory.Exists(screenshotDirectoryPath))
            {
                Directory.CreateDirectory(screenshotDirectoryPath);
            }

            VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker());

            driver.TakeScreenshot(vcd).ToMagickImage().Write(new FileInfo(Path.Combine(Path.GetFullPath(screenshotDirectoryPath), fileName)));
        }
    }
}
