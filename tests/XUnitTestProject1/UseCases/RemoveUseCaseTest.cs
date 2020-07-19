using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Core.Domain.Entities;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.UseCases;
using Xunit;

namespace ToDo.Core.Tests.UseCases
{
    public class RemoveUseCaseTest
    {
        private InMemoryDataContext _dataContext;
        private InMemoryDataGateway _dataGateway;
        private string _itemCreatedId;


        public RemoveUseCaseTest()
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
        public void ShouldRemoveAnItem()
        {
            var removeUseCase = new Remove(_dataGateway);
            removeUseCase.Execute(_itemCreatedId);

            var item = _dataContext.Items.FirstOrDefault(x => x.Id.ToString() == _itemCreatedId);
            Assert.Null(item);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("non-existent-id")]
        public void WhenPassingAnInvalidIdShouldThrowAnException(string id)
        {
            var removeUseCase = new Remove(_dataGateway);

            Assert.Throws<ArgumentException>(() =>
            {
                removeUseCase.Execute(id);
            });
        }
    }
}
