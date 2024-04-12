using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestAutomationFramework.Core.Configuration;

namespace TestAutomationFramework.Core.DriverFactory
{
    public abstract class BaseDriverFactory
    {
        public abstract IWebDriver CreateDriver(ConfigModel model);
    }
}
