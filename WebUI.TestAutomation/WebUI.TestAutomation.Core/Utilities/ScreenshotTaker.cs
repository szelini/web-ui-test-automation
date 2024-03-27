using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.TestAutomation.Core.Utilities
{
    public static class ScreenShotTaker
    {
        public static void TakeScreenShot(IWebDriver driver, string testName, string screenshotDirectoryPath)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            if (!Directory.Exists(screenshotDirectoryPath))
            {
                Directory.CreateDirectory(screenshotDirectoryPath);
            }
            screenshot.SaveAsFile(Path.Combine(Path.GetFullPath(screenshotDirectoryPath), $"{testName}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss.fffff}.png"));
        }
    }
}
