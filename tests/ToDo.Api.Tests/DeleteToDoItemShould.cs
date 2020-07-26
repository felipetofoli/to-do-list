using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ToDo.Core.Domain.Gateways;
using Xunit;

namespace ToDo.Api.Tests
{
    public class DeleteToDoItemShould : IClassFixture<WebApplicationFactory<ToDo.Api.Startup>>
    {
        private readonly HttpClient _client;

        public DeleteToDoItemShould(WebApplicationFactory<ToDo.Api.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnOk()
        {
            var existingItemId = InMemoryDataContext.ITEM_TO_REMOVE_ID;
            var response = await _client.DeleteAsync($"api/todoitems/{existingItemId}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnBadRequest()
        {
            var nonExistingItemId = "non-existing-id";
            var response = await _client.DeleteAsync($"api/todoitems/{nonExistingItemId}");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
