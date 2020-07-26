using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ToDo.Api.Models;
using Xunit;

namespace ToDo.Api.Tests
{
    public class GetToDoItemShould : IClassFixture<WebApplicationFactory<ToDo.Api.Startup>>
    {
        private readonly HttpClient _client;

        public GetToDoItemShould(WebApplicationFactory<ToDo.Api.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnList()
        {
            var response = await _client.GetAsync("api/todoitems");

            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<ToDoItemViewModel>>(stringResponse).ToList();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.Count > 0);
        }
    }
}
