using NUnit.Framework.Interfaces;
using TestAutomationFramework.Business.ApiClients;
using TestAutomationFramework.Core.Configuration;
using TestAutomationFramework.Core.Utilities;

namespace TestAutomationFramework.ApiTests
{
    public class ApiBaseTest
    {
        protected JsonPlaceholderTypicodeClient client;
        protected ApiConfiguration configuration;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            configuration = new ApiConfiguration("apitest_config.json");
            Logger.InitLogger(configuration.Model.LogDirectory, "log_apitests.txt", configuration.Model.LogLevel);
        }

        [SetUp]
        public void Setup()
        {
            Logger.Info($"{TestContext.CurrentContext.Test.Name} started");
            client = new JsonPlaceholderTypicodeClient(configuration.Model.AppUrl);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Logger.Error($"{TestContext.CurrentContext.Test.Name} failed");
            }

            Logger.Info($"{TestContext.CurrentContext.Test.Name} finished");
            client.Dispose();
        }
    }
}