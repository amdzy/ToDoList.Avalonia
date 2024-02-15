using System.Collections.Generic;

namespace TodoList.Avalonia;

public class ToDoListService
{
    public IEnumerable<ToDoItem> GetItems()
    {
        return [
            new ToDoItem{Description = "Walk the dog"},
            new ToDoItem{Description = "Buy some milk"},
            new ToDoItem{Description = "Learn Avalonia",IsChecked = true}
        ];
    }
}
