using RestSharp;
using TestAutomationFramework.Business.ApiModels;
using TestAutomationFramework.Core.ApiClient;

namespace TestAutomationFramework.Business.ApiClients
{
    public  class JsonPlaceholderTypicodeClient : BaseApiClient
    {
        public JsonPlaceholderTypicodeClient(string url) :base(url)
        {
        }

        public  Task<List<User>> GetUsers(RestRequest request)
        {
            return _client.GetAsync<List<User>>(request);
        }

        public async Task<User> GetUser(RestRequest request)
        {
            var response = await _client.GetAsync<User>(request);
            return response;
        }

        public  async Task<RestResponse> ExecuteRequest(RestRequest request)
        {
            var response = _client.Execute(request);
            return response;
        }

        public async Task <User> PostUser(RestRequest request)
        {
            var response = await _client.PostAsync<User>(request);
            return response;
        }
    }
}
