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
        public string Log { get; set; }

        public Options Options { get; set; }

        public string ScreenshotDirectory { get; set; }

    }
}
