using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Core.Domain.Entities;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.UseCases;
using Xunit;

namespace ToDo.Core.Tests.UseCases
{
    public class UndoUseCaseTest
    {
        private InMemoryDataContext _dataContext;
        private InMemoryDataGateway _dataGateway;
        private string _itemCreatedId;


        public UndoUseCaseTest()
        {
            // Fake data context
            var toDoItem = new ToDoItem("itemName");
            toDoItem.Do();

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
        public void ShouldMarkAnItemAsNotDone()
        {
            var undoUseCase = new Undo(_dataGateway);
            undoUseCase.Execute(_itemCreatedId);

            var notDoneItem = _dataContext.Items.FirstOrDefault(x => x.Id.ToString() == _itemCreatedId);
            Assert.NotNull(notDoneItem);
            Assert.False(notDoneItem.Done);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("non-existent-id")]
        public void WhenPassingAnInvalidIdShouldThrowAnException(string id)
        {
            var undoUseCase = new Undo(_dataGateway);

            Assert.Throws<ArgumentException>(() =>
            {
                undoUseCase.Execute(id);
            });
        }
    }
}
