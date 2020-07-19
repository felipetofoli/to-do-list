using System.Collections.Generic;
using ToDo.Core.Domain.Entities;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.UseCases;
using Xunit;

namespace ToDo.Core.Tests.UseCases
{
    public class ListUseCaseTest
    {
        [Fact]
        public void ShouldGetTwoItems()
        {
            // Fake data context
            var toDoItem1 = new ToDoItem("itemName1");
            var toDoItem2 = new ToDoItem("itemName2");
            var dataContext = new InMemoryDataContext()
            {
                Items = new List<ToDoItem>
                {
                    toDoItem1,
                    toDoItem2,
                }
            };
            var dataGateway = new InMemoryDataGateway(dataContext);

            // Get items
            var listUseCase = new List(dataGateway);
            var items = listUseCase.Execute();

            Assert.NotNull(items);
            Assert.True(items.Count == 2);
        }

        [Fact]
        public void ShouldGetACollectionWithoutItems()
        {
            // Fake data context
            var dataContext = new InMemoryDataContext()
            {
                Items = new List<ToDoItem>()
            };
            var dataGateway = new InMemoryDataGateway(dataContext);

            // Get items
            var listUseCase = new List(dataGateway);
            var items = listUseCase.Execute();

            Assert.NotNull(items);
            Assert.True(items.Count == 0);
        }
    }
}
