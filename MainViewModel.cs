using System.Windows.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CollectionTest;

public partial class MainViewModel : ObservableObject
{
    private List<Person> people = new List<Person> () {
        new Person("Bob","Smith"),
        new Person("Jim","Brown"),
        new Person("Fred","Robinson")
    };
    public List<Person> People => people;

    [ObservableProperty]
    private string commandType = "";

    [ObservableProperty]
    private string commandParameter = "";

    [ObservableProperty]
    private string priorCommandType = "";

    [ObservableProperty]
    private string priorCommandParameter = "";

    [ObservableProperty]
    private bool templateSelector = false;

    void ShowCommandInfo(string t, object commandParam)
    {
        PriorCommandType = CommandType;
        PriorCommandParameter = CommandParameter;
        CommandType = t;
        if (commandParam is Person p)
            CommandParameter = p.Name;
        else if (commandParam is null)
            CommandParameter = "Command parameter was null";
        else
            CommandParameter = "Command parameter was not a Person";
    }

    [RelayCommand]
    private void ShowTouch(object commandParam)
    {
        ShowCommandInfo("Touch", commandParam);
    }

    private void ShowLongPress(object commandParam)
    {
        ShowCommandInfo("Long Press", commandParam);
        TemplateSelector = !TemplateSelector;
    }
    private ICommand? showLongPressCommand = null;
    public ICommand ShowLongPressCommand => showLongPressCommand ??= new Command (ShowLongPress);

    private void ShowTap(object commandParam)
    {
        ShowCommandInfo("Tap", commandParam);
    }
    private ICommand? showTapCommand = null;
    public ICommand ShowTapCommand => showTapCommand ??= new Command(ShowTap);
}

public class Person(string firstName, string lastName)
{
    public string Name => lastName+", " + firstName;
}
