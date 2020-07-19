using System;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.Domain.UseCases;

namespace ToDo.Core.UseCases
{
    public class Undo : IDoUseCase
    {
        private readonly IDataGateway _dataGateway;

        public Undo(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public void Execute(string id)
        {
            var item = _dataGateway.Get(id);

            if (item == null)
                throw new ArgumentException($"Item with id '{id}' does not exist.");

            item.Undo();

            _dataGateway.Update(item);
        }
    }
}
