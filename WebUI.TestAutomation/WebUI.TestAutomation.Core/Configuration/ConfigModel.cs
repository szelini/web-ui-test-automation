using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.TestAutomation.Core.Configuration
{
    public class ConfigModel
    {
        public string Browser { get; set; }

        public bool RunHeadlessMode { get; set; }

        public string DownloadDirectory { get; set; }

        public string ScreenshotDirectory { get; set; }

        public string LogDirectory { get; set; }

        public string LogLevel { get; set; }

    }
}
