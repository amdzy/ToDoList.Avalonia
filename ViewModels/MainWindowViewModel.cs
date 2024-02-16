using ReactiveUI;
using System;
using System.Reactive.Linq;

namespace ToDoList.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;

    private ToDoListService _toDoListService;
    public MainWindowViewModel()
    {
        _toDoListService = new ToDoListService();
        ToDoList = new ToDoListViewModel(_toDoListService.GetItems());
        ToDoList.ListItems.CollectionChanged += (obj, e) =>
        {
            ToDoListService.UpdateItems(ToDoList.ListItems);
        };
        _contentViewModel = ToDoList;
    }

    public ToDoListViewModel ToDoList { get; }

    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }

    public void AddItem()
    {
        AddItemViewModel addItemViewModel = new();

        Observable.Merge(
            addItemViewModel.OkCommand,
            addItemViewModel.CancelCommand.Select(_ => (ToDoItem?)null))
            .Take(1)
            .Subscribe(newItem =>
            {
                if (newItem != null)
                {
                    ToDoList.ListItems.Add(newItem);
                }
                ContentViewModel = ToDoList;
            });

        ContentViewModel = addItemViewModel;
    }
}
