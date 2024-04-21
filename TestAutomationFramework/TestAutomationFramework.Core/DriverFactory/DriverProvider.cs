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
