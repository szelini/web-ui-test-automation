using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationFramework.Core.Configuration
{
    public class Configuration
    {
        public  ConfigModel Model { get; }

        public Configuration(string configfile)
        {
            Model = new ConfigModel();
            new ConfigurationBuilder()
                .AddJsonFile(configfile)
                .Build()
                .Bind(Model);
        }
    }
}
