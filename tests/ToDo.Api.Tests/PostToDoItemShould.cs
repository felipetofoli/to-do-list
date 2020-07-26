using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ToDo.Api.Tests
{
    public class PostToDoItemShould : IClassFixture<WebApplicationFactory<ToDo.Api.Startup>>
    {
        private readonly HttpClient _client;

        public PostToDoItemShould(WebApplicationFactory<ToDo.Api.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnOkAndToDoItemId()
        {
            var requestContent = new { Name = "Item #1 name" };
            var payload = JsonConvert.SerializeObject(requestContent);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/todoitems", content);
            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.False(string.IsNullOrEmpty(stringResponse));
            Assert.False(string.IsNullOrWhiteSpace(stringResponse));
        }

        [Fact]
        public async Task ReturnBadRequest()
        {
            var requestContent = new { Name = "" };
            var payload = JsonConvert.SerializeObject(requestContent);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/todoitems", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
