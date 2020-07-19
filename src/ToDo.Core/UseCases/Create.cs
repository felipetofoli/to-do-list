using ToDo.Core.Domain.Entities;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.Domain.UseCases;

namespace ToDo.Core.UseCases
{
    public class Create : ICreateUseCase
    {
        private readonly IDataGateway _dataGateway;

        public Create(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public string Execute(string name)
        {
            var item = new ToDoItem(name);

            _dataGateway.Add(item);

            return item.Id.ToString();
        }
    }
}
