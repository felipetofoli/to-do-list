using System;
using ToDo.Core.Domain.Entities;
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
            Assert.Throws<ArgumentException>(() =>
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
    }
}
