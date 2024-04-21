using TestAutomationFramework.Core.Utilities;

namespace TestAutomationFramework.Core.Configuration
{
    public  class ApiConfiguration
    {
        public ApiConfigModel Model { get; }

        public ApiConfiguration(string configfile)
        {
            Model = JsonParser.DeserializeJsonFileToObject<ApiConfigModel>(configfile);
        }
    }
}
