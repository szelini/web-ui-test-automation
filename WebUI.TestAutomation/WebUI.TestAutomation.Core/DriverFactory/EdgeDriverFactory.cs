﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.TestAutomation.Core.Configuration;

namespace WebUI.TestAutomation.Core.DriverFactory
{
    public class EdgeDriverFactory : BaseDriverFactory
    {
        public override IWebDriver CreateDriver(Options options)
        {
            var edgeOptions = new EdgeOptions();
            
            if (options.RunHeadlessMode)
            {
                edgeOptions.AddArgument("--headless");
            }

            if (!string.IsNullOrEmpty(options.DownloadDirectory))
            {
                edgeOptions.AddUserProfilePreference("download.default_directory", options.DownloadDirectory);

            }
            return new EdgeDriver(edgeOptions);
        }
    }
}
