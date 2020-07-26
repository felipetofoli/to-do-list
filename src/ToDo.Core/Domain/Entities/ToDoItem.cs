using System;
using ToDo.Core.Domain.Exceptions;

namespace ToDo.Core.Domain.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Done { get; private set; }

        private ToDoItem()
        {
        }

        public ToDoItem(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessException("Name is required.");

            this.Id = Guid.NewGuid();
            this.Name = name;
        }

        public void Do()
        {
            this.Done = true;
        }

        public void Undo()
        {
            this.Done = false;
        }

        public static ToDoItem LoadFrom(Guid id, string name, bool done)
        {
            return new ToDoItem
            {
                Id = id,
                Name = name,
                Done = done
            };
        }
    }
}
