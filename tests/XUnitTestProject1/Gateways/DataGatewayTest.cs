using ToDo.Core.Domain.Entities;
using ToDo.Core.Domain.Gateways;
using Xunit;

namespace ToDo.Core.Tests.Gateways
{
    public class DataGatewayTest
    {
        private InMemoryDataContext _dataContext;
        private InMemoryDataGateway _dataGateway;

        public DataGatewayTest()
        {
            _dataContext = new InMemoryDataContext();
            _dataGateway = new InMemoryDataGateway(_dataContext);
        }

        [Fact]
        public void BasicDataGatewayUsage()
        {
            // Get all, empty list
            var items = _dataGateway.GetAll();
            Assert.True(items.Count == 0);

            // Add new item
            var newItemName = "newItemName";
            var newItem = new ToDoItem(newItemName);
            _dataGateway.Add(newItem);

            var gotItem = _dataGateway.Get(newItem.Id.ToString());
            Assert.NotNull(gotItem);
            Assert.Equal(newItemName, gotItem.Name);
            Assert.False(gotItem.Done);

            // Do item
            gotItem.Do();
            _dataGateway.Update(gotItem);

            var doneItem = _dataGateway.Get(gotItem.Id.ToString());
            Assert.NotNull(doneItem);
            Assert.Equal(newItemName, doneItem.Name);
            Assert.True(doneItem.Done);

            // Undo item
            doneItem.Undo();
            _dataGateway.Update(doneItem);

            var undoneItem = _dataGateway.Get(doneItem.Id.ToString());
            Assert.NotNull(undoneItem);
            Assert.Equal(newItemName, undoneItem.Name);
            Assert.False(undoneItem.Done);

            // Get all, with items
            items = _dataGateway.GetAll();
            Assert.True(items.Count == 1);
        }
    }
}
