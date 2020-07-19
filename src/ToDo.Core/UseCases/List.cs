using System.Collections.Generic;
using ToDo.Core.Domain.Entities;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.Domain.UseCases;

namespace ToDo.Core.UseCases
{
    public class List : IListUseCase
    {
        private readonly IDataGateway _dataGateway;

        public List(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public ICollection<ToDoItem> Execute()
        {
            return _dataGateway.GetAll();
        }
    }
}
