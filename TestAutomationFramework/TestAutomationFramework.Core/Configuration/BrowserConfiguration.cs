using TestAutomationFramework.Core.Utilities;

namespace TestAutomationFramework.Core.Configuration
{
    public class BrowserConfiguration
    {
        public  BrowserConfigModel Model { get; }

        public BrowserConfiguration()
        {
           //Model = JsonParser.DeserializeJsonFileToObject<BrowserConfigModel>(configfile);

            Model = new BrowserConfigModel();
           
        }
    }
}
