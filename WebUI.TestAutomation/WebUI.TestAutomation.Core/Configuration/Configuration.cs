using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.TestAutomation.Core.Configuration
{
    public static class Configuration
    {
        public static ConfigModel Model { get; }

        static Configuration()
        {
            Model = new ConfigModel();
            new ConfigurationBuilder()
                .AddJsonFile("./Configuration/config.json")
                .Build()
                .Bind(Model);
        }
    }
}
