using System.Linq;
using ToDo.Core.Domain.Exceptions;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.UseCases;
using Xunit;

namespace ToDo.Core.Tests.UseCases
{
    public class CreateUseCaseTest
    {
        [Fact]
        public void ShouldCreateAnItemAndReturnId()
        {
            var dataContext = new InMemoryDataContext();
            var gateway = new InMemoryDataGateway(dataContext);
            var useCase = new Create(gateway);

            var itemName = "itemName";
            var itemId = useCase.Execute(itemName);

            Assert.NotNull(itemId);
            Assert.NotEmpty(itemId);

            var insertedItem = dataContext.Items.FirstOrDefault(x => x.Id.ToString() == itemId);
            Assert.NotNull(insertedItem);
            Assert.Equal(itemName, insertedItem.Name);
            Assert.False(insertedItem.Done);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void WhenPassingBlankNameShouldThrowAnException(string name)
        {
            var dataContext = new InMemoryDataContext();
            var gateway = new InMemoryDataGateway(dataContext);
            var useCase = new Create(gateway);

            Assert.Throws<BusinessException>(() =>
            {
                var result = useCase.Execute(name);
            });
        }
    }
}
