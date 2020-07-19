using System.Collections.Generic;
using ToDo.Core.Domain.Entities;

namespace ToDo.Core.Domain.Gateways
{
    public interface IDataGateway
    {
        ToDoItem Get(string id);

        ICollection<ToDoItem> GetAll();

        void Add(ToDoItem item);

        void Update(ToDoItem item);

        void Remove(ToDoItem item);
    }
}