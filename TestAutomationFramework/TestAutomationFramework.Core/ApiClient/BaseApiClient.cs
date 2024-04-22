using RestSharp;

namespace TestAutomationFramework.Core.ApiClient
{
    public class BaseApiClient : IDisposable
    {
        protected readonly RestClient _client;
        public string BaseUrl { get;  }

        protected BaseApiClient(string url)
        {
            _client = new RestClient();
            BaseUrl = url;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
