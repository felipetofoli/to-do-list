using System.Collections.Generic;
using ToDo.Core.Domain.Entities;

namespace ToDo.Core.Domain.Gateways
{
    public class InMemoryDataContext
    {
        public ICollection<ToDoItem> Items = new List<ToDoItem>();
    }
}
