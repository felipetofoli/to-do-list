using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Core.Domain.Entities;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.UseCases;
using Xunit;

namespace ToDo.Core.Tests.UseCases
{
    public class DoUseCaseTest
    {
        private InMemoryDataContext _dataContext;
        private InMemoryDataGateway _dataGateway;
        private string _itemCreatedId;


        public DoUseCaseTest()
        {
            // Fake data context
            var toDoItem = new ToDoItem("itemName");
            _dataContext = new InMemoryDataContext()
            {
                Items = new List<ToDoItem>
                {
                    toDoItem
                }
            };
            _dataGateway = new InMemoryDataGateway(_dataContext);

            // Id of the created item
            _itemCreatedId = toDoItem.Id.ToString();
        }

        [Fact]
        public void ShouldMarkAnItemAsDone()
        {
            var doUseCase = new Do(_dataGateway);
            doUseCase.Execute(_itemCreatedId);

            var doneItem = _dataContext.Items.FirstOrDefault(x => x.Id.ToString() == _itemCreatedId);
            Assert.NotNull(doneItem);
            Assert.True(doneItem.Done);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("non-existent-id")]
        public void WhenPassingAnInvalidIdShouldThrowAnException(string id)
        {
            var doUseCase = new Do(_dataGateway);

            Assert.Throws<ArgumentException>(() =>
            {
                doUseCase.Execute(id);
            });
        }
    }
}
