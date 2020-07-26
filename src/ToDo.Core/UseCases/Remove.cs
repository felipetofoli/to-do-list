using ToDo.Core.Domain.Exceptions;
using ToDo.Core.Domain.Gateways;
using ToDo.Core.Domain.UseCases;

namespace ToDo.Core.UseCases
{
    public class Remove : IRemoveUseCase
    {
        private readonly IDataGateway _dataGateway;

        public Remove(IDataGateway dataGateway)
        {
            _dataGateway = dataGateway;
        }

        public void Execute(string id)
        {
            var item = _dataGateway.Get(id);

            if (item == null)
                throw new BusinessException($"Item with id '{id}' does not exist.");

            _dataGateway.Remove(item);
        }
    }
}
