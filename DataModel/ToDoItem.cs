using System;

namespace ToDoList.Avalonia;

public class ToDoItem
{
    public string Description { get; set; } = String.Empty;
    public bool IsChecked { get; set; }
}
