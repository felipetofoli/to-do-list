using System.Collections.Generic;
using ToDo.Core.Domain.Entities;

namespace ToDo.Core.Domain.Gateways
{
    public class InMemoryDataContext
    {
        public const string ITEM_TO_REMOVE_ID = "ec635878-5bc7-45c1-bab1-9f95e268e97c";
        public const string ITEM_TO_MARK_AS_DONE_ID = "a2113585-8c06-42b8-a184-80aca7bdebb5";
        public const string ITEM_TO_MARK_AS_NOT_DONE_ID = "4dbf7836-7653-4ce1-916a-73853e966224";
        public const string ITEM4_ID = "78535365-20d9-4e01-958c-3d2ddda5b180";
        public const string ITEM5_ID = "ec9aa660-a581-4fdd-aff7-a87f2ee0e83d";
        public const string ITEM6_ID = "c7fd8f6b-14a9-4ab0-986d-169586fc0c6b";
        public const string ITEM7_ID = "7fb29f97-6dba-4320-83b5-57fe99c9beea";
        public const string ITEM8_ID = "6e529b0a-f28d-4a04-a1fc-2d463058d9c9";
        public const string ITEM9_ID = "6dbda56c-a595-49d0-8ad9-4c99f5a259a0";
        public const string ITEM10_ID = "7958126a-9490-443b-9802-632d26e6cfe8";

        public ICollection<ToDoItem> Items = new List<ToDoItem>();

        public InMemoryDataContext()
        {
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM_TO_REMOVE_ID), "Remove this item", true));
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM_TO_MARK_AS_DONE_ID), "Mark this item as done", false));
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM_TO_MARK_AS_NOT_DONE_ID), "Undo this item", true));
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM4_ID), "Item #4", false));
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM5_ID), "Item #5", true));
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM6_ID), "Item #6", false));
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM7_ID), "Item #7", true));
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM8_ID), "Item #8", false));
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM9_ID), "Item #9", true));
            Items.Add(ToDoItem.LoadFrom(new System.Guid(ITEM10_ID), "Item #10", false));
        }
    }
}
