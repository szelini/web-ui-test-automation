using System.Text;

namespace TestAutomationFramework.Core.Utilities
{
    public class RestRequestResourceBuilder
    {
        private RestRequestResource _requestResource = new RestRequestResource();
        
        public RestRequestResourceBuilder AddBaseUrl(string baseUrl)
        {
            _requestResource.BaseUrl = baseUrl;
            return this;
        }

        public RestRequestResourceBuilder AddEndpoint(string endpoint)
        {
            _requestResource.Endpoint = endpoint;
            return this;
        }

        public string BuildResourceString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_requestResource.BaseUrl)
                .Append("/")
                .Append(_requestResource.Endpoint);
            return sb.ToString();
        }
    }
}
