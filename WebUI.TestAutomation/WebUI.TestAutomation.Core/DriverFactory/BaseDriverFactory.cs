using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebUI.TestAutomation.Core.Configuration;

namespace WebUI.TestAutomation.Core.DriverFactory
{
    public abstract class BaseDriverFactory
    {
        public abstract IWebDriver CreateDriver(ConfigModel model);
    }
}
