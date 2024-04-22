using RestSharp;
using System.Net;
using System.Text;
using TestAutomationFramework.Business.ApiModels;
using TestAutomationFramework.Core.Utilities;

namespace TestAutomationFramework.ApiTests
{
    [Category("API")]
    public class ApiTests : ApiBaseTest
    {
        // Tasks 1. Validate that the list of users can be received successfully

        // Validate that user receives 200 OK response code.There are no error messages
        [TestCase("/users")]
        public async Task HttpStatusCodeTestAsync(string endpoint)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
                .AddBaseUrl(client.BaseUrl)
                .AddEndpoint(endpoint)
                .BuildResourceString());
            var response = await client.ExecuteRequest(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));    
        }

        // Validate that user recives a list of users with the following information: "id",  "name", "username", "email", "address”,     "phone",   "website",  "company";
        [TestCase("/users")]
        public async Task UsersListBack(string endpoint)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
               .AddBaseUrl(client.BaseUrl)
               .AddEndpoint(endpoint)
               .BuildResourceString());
            var response = await client.GetUsers(request);
            Assert.That(response.Count, Is.Not.Zero);
        }

        //Tasks 2. Validate response header for a list of users

        //2. Validate content-type header exists in the obtained response
        [TestCase("/users")]
        public async Task HeaderExists(string endpoint)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
                .AddBaseUrl(client.BaseUrl)
                .AddEndpoint(endpoint)
                .BuildResourceString());
            var response = await client.ExecuteRequest(request);
            var result = response.Headers;
            Assert.That(result.Count, Is.Not.Zero);
        }

        //3. The value of the content-type header is application/json; charset=utf-8
        [TestCase("/users")]
        public async Task HeaderProperties(string endpoint)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
               .AddBaseUrl(client.BaseUrl)
               .AddEndpoint(endpoint)
               .BuildResourceString());
            var response = await client.ExecuteRequest(request);
            var result = response.ContentHeaders.Any(t => t.Value.Equals("application/json; charset=utf-8"));
            Assert.That(result, Is.True);
        }

        //Tasks 3. Validate response header for a list of users
        
        // 2. Validate that the content of the response body is the array of 10 users
        [Test]
        [TestCase("/users")]
        public async Task ArrayOf10Users(string endpoint)
        {
             var request = new RestRequest(new RestRequestResourceBuilder()
                .AddBaseUrl(client.BaseUrl)
                .AddEndpoint(endpoint)
                .BuildResourceString());
            var response = await client.GetUsers(request);
            Assert.That(response.ToArray().Length, Is.EqualTo(10));
        }

        //3. Validate that each user should be with different ID
        [Test]
        [TestCase("/users")]
        public async Task EachUserOfDifferentId(string endpoint)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
                .AddBaseUrl(client.BaseUrl)
                .AddEndpoint(endpoint)
                .BuildResourceString());
            var response = await client.GetUsers(request);
            int result = response.DistinctBy(x => x.Id).Count();
            Assert.That(result, Is.EqualTo(10));
        }

        //4. Validate that each user should be with non-empty Name and Username
        [Test]
        [TestCase("/users")]
        public async Task EveryUserHasNameAndUsername(string endpoint)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
               .AddBaseUrl(client.BaseUrl)
               .AddEndpoint(endpoint)
               .BuildResourceString());
            var response = await client.GetUsers(request);
            bool result = response.All(t => !string.IsNullOrEmpty(t.Username) && !string.IsNullOrEmpty(t.Name));
            Assert.That(result, Is.True);
        }

        // 5. Validate that each user contains the Company with non-empty Name 
        [TestCase("/users")]
        public async Task EveryUserHasCompanyNameNotMepty(string endpoint)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
               .AddBaseUrl(client.BaseUrl)
               .AddEndpoint(endpoint)
               .BuildResourceString());
            var response = await client.GetUsers(request);
            bool result = response.All(t => !string.IsNullOrEmpty(t.Company.Name));
            Assert.That(result, Is.True);
        }

        //Tasks 4.Validate that user can be created

        // Validate that response is not empty and contains the ID value
        [TestCase("/users", "Szaffi", "Szaffi1")]
        public async Task PostAUser(string endpoint, string name, string username)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
               .AddBaseUrl(client.BaseUrl)
               .AddEndpoint(endpoint)
               .BuildResourceString());
            var param = new User { Name = name, Username = username };
            request.AddJsonBody(param);
            var response = await client.PostUser(request);
            Assert.That(response.Id, Is.Not.Zero);
        }

        // Validate that user receives 201 Created response code. There are no error messages
        [TestCase("/users", "Szaffi", "Szaffi1")]
        public async Task PostAUserResponseCode(string endpoint, string name, string username)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
                .AddBaseUrl(client.BaseUrl)
                .AddEndpoint(endpoint)
                .BuildResourceString(), Method.Post);
            var param = new User { Name = name, Username = username };
            request.AddJsonBody(param);
            var response = await client.ExecuteRequest(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        //Tasks 5. Validate that user is notified if resource doesn’t exist
        [TestCase("/invalidendpoint")]
        public async Task HttpStatusCode404TestAsync(string endpoint)
        {
            var request = new RestRequest(new RestRequestResourceBuilder()
                .AddBaseUrl(client.BaseUrl)
                .AddEndpoint(endpoint)
                .BuildResourceString());
            var response = await client.ExecuteRequest(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
