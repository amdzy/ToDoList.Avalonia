﻿namespace TodoList.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var service = new ToDoListService();
        ToDoList = new ToDoListViewModel(service.GetItems());
    }

    public ToDoListViewModel ToDoList { get; }
}
