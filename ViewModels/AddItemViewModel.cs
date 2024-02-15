using System.Reactive;
using ReactiveUI;

namespace ToDoList.Avalonia.ViewModels;

public class AddItemViewModel : ViewModelBase
{
    public string _description = string.Empty;

    public ReactiveCommand<Unit, ToDoItem> OkCommand { get; }
    public ReactiveCommand<Unit, Unit> CloseCommand { get; }

    public AddItemViewModel()
    {
        var isValidObservable = this.WhenAnyValue(x => x.Description, x => !string.IsNullOrEmpty(x));

        OkCommand = ReactiveCommand.Create(() => new ToDoItem { Description = Description }, isValidObservable);
        CloseCommand = ReactiveCommand.Create(() => { });
    }

    public string Description { get => _description; set => this.RaiseAndSetIfChanged(ref _description, value); }
}
