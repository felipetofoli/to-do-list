using System;
using ToDo.Core.Domain.Entities;
using ToDo.Core.Domain.Exceptions;
using Xunit;

namespace ToDo.Core.Tests.Domain.Entities
{
    public class ToDoItemTest
    {
        [Theory]
        [InlineData("completedItem")]
        [InlineData("notCompletedItem")]
        public void WhenCreateNewToDoItemShouldReturnNewInstance(string name)
        {
            var itemInitialStatus = false;

            var item = new ToDoItem(name);

            Assert.Equal(name, item.Name);
            Assert.Equal(itemInitialStatus, item.Done);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenCreateNewToDoItemWithBlankNameShouldThrowAnException(string name)
        {
            Assert.Throws<BusinessException>(() =>
            {
                var item = new ToDoItem(name);
            });
        }

        [Fact]
        public void WhenDoAItemTheStatusShouldBeAsDone()
        {
            var item = new ToDoItem("itemName");

            item.Do();

            Assert.True(item.Done);
        }

        [Fact]
        public void WhenUndoAItemTheStatusShouldBeAsNotDone()
        {
            var item = new ToDoItem("itemName");

            item.Undo();

            Assert.False(item.Done);
        }

        [Fact]
        public void WhenUndoAItemEvenAfterCompleteItTheStatusShouldBeAsNotDone()
        {
            var item = new ToDoItem("itemName");

            item.Do();
            item.Undo();

            Assert.False(item.Done);
        }

        [Theory]
        [InlineData("1e607c89-62ef-48d4-bd59-59e97753dd1b", "item #1", true)]
        [InlineData("9e9df764-4900-4e22-977a-c217b282ad3b", "item #2", false)]
        public void WhenLoadFromParamsShouldAssignTheSameValues(string id, string name, bool done)
        {
            var todoItem = ToDoItem.LoadFrom(new Guid(id), name, done);

            Assert.Equal(id, todoItem.Id.ToString());
            Assert.Equal(name, todoItem.Name);
            Assert.Equal(done, todoItem.Done);
        }
    }
}
