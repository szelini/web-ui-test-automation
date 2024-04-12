using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace TestAutomationFramework.Core.Utilities
{
    public static class ScreenShotTaker
    {
        public static void TakeScreenShot(IWebDriver driver, string testName, string screenshotDirectoryPath)
        {
            if (!Directory.Exists(screenshotDirectoryPath))
            {
                Directory.CreateDirectory(screenshotDirectoryPath);
            }

            VerticalCombineDecorator vcd = new VerticalCombineDecorator(new ScreenshotMaker());

            driver.TakeScreenshot(vcd).ToMagickImage().Write(new FileInfo(Path.Combine(Path.GetFullPath(screenshotDirectoryPath), $"{testName}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png")));
        }
    }
}
