using System;

namespace ToDo.Core.Domain.Entities
{
    public class ToDoItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Done { get; private set; }

        public ToDoItem(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.");

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
    }
}
