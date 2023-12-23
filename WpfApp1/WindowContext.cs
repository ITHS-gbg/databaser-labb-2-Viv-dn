using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Labb2_DbFirst_Template.Entities;
using Labb2_DbFirst_Template.Handlers;

namespace BookStore;

public class WindowContext : INotifyPropertyChanged
{

    private int myVar;

    public int MyProperty
    {
        get { return myVar; }
        set { myVar = value; }
    }

    public ObservableCollection<BookModel> Products { get; set; } = new();
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}