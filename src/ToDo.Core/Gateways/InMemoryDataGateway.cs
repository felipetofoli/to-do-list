using System.Collections.Generic;
using System.Linq;
using ToDo.Core.Domain.Entities;

namespace ToDo.Core.Domain.Gateways
{
    public class InMemoryDataGateway : IDataGateway
    {
        private static readonly ICollection<ToDoItem> _items = new List<ToDoItem>();
        private readonly InMemoryDataContext _context;

        public InMemoryDataGateway(InMemoryDataContext dataContext)
        {
            _context = dataContext;
        }

        public ToDoItem Get(string id)
        {
            return _context.Items.FirstOrDefault(x => x.Id.ToString() == id);
        }

        public ICollection<ToDoItem> GetAll()
        {
            return _context.Items;
        }

        public void Add(ToDoItem item)
        {
            _context.Items.Add(item);
        }

        public void Update(ToDoItem item)
        {
            var itemId = item.Id.ToString();
            var oldItem = Get(itemId);

            _context.Items.Remove(oldItem);
            _context.Items.Add(item);
        }

        public void Remove(ToDoItem item)
        {
            _context.Items.Remove(item);
        }
    }
}
