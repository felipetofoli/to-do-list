using System.Collections.Generic;
using ToDo.Core.Domain.Entities;

namespace ToDo.Core.Domain.UseCases
{
    public interface IListUseCase
    {
        ICollection<ToDoItem> Execute();
    }
}
