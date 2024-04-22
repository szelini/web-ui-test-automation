using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace TestAutomationFramework.Core.Utilities
{
    public static class Logger
    {
        private static ILogger logger;

        public static void Info(string message)
        {
            logger.Information(message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }

        public static void Warning(string message)
        {
            logger.Warning(message);
        }

        public static void InitLogger(string logDirectoryPath, string logLevel)
        {
            FolderMaintainer.DirectoryCreator(logDirectoryPath);
            
            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = (LogEventLevel)Enum.Parse(typeof(LogEventLevel), logLevel);

            logger = new LoggerConfiguration()
             .MinimumLevel.ControlledBy(levelSwitch)
             .WriteTo.Console()
             .WriteTo.File(Path.Combine(logDirectoryPath, $"log.txt"), rollingInterval: RollingInterval.Day) 
             .CreateLogger();

            //{ DateTime.Now.ToShortDateString()}
        }
    }
}
