using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Core.DriverFactory
{
    public enum Drivers
    {
        Chrome,
        Edge
    }

    public class DriverProvider
    {
        public static BaseDriverFactory GetDriverFactory(Drivers driver)
        {
            return driver switch
            {
                Drivers.Chrome => new ChromeDriverFactory(),
                Drivers.Edge => new EdgeDriverFactory(),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
