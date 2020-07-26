using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ToDo.Core.Domain.Gateways;
using Xunit;

namespace ToDo.Api.Tests
{
    public class PutDoToDoItemShould : IClassFixture<WebApplicationFactory<ToDo.Api.Startup>>
    {
        private readonly HttpClient _client;

        public PutDoToDoItemShould(WebApplicationFactory<ToDo.Api.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnOk()
        {
            var existingItemId = InMemoryDataContext.ITEM_TO_MARK_AS_DONE_ID;

            var content = new StringContent("");
            var response = await _client.PutAsync($"api/todoitems/{existingItemId}/do", content);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ReturnBadRequest()
        {
            var nonExistingItemId = "non-existing-id";

            var content = new StringContent("");
            var response = await _client.PutAsync($"api/todoitems/{nonExistingItemId}/undo", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
