using Labb2_DbFirst_Template.Handlers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Labb2_DbFirst_Template.Entities;

namespace BookStore;

public class StoreWindowContext : INotifyPropertyChanged
{
    private string _title;

    public string Title
    {
        get { return _title; }
        set
        {
            _title = value; 
            OnPropertyChanged();
        }
    }

    private int? _stock;

    public int? Stock
    {
        get { return _stock; }
        set
        {
            _stock = value; 
            OnPropertyChanged();
        }
    }


    public ObservableCollection<Inventory> StoreBooks { get; set; } = new();

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