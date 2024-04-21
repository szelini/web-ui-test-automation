using NUnit.Framework.Interfaces;
using RestSharp;
using TestAutomationFramework.Business.ApiClients;
using TestAutomationFramework.Business.ApiModels;
using TestAutomationFramework.Core.ApiClient;
using TestAutomationFramework.Core.Configuration;
using TestAutomationFramework.Core.DriverFactory;
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
            Logger.InitLogger(configuration.Model.LogDirectory, configuration.Model.LogLevel);
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