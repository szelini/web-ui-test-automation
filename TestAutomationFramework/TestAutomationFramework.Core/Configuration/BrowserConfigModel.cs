
namespace TestAutomationFramework.Core.Configuration
{
    public class BrowserConfigModel : BaseConfigModel
    {
        public string Browser { get; set; }

        public bool RunHeadlessMode { get; set; }

        public string DownloadDirectory { get; set; }

        public string ScreenshotDirectory { get; set; }

        public string AppUrl { get; set; }

    }
}
