using System.ComponentModel;

namespace BookStore;

public class SharedWindowContext : INotifyPropertyChanged
{
    private int _selectedId;
    public int SelectedId
    {
        get { return _selectedId; }
        set
        {
            _selectedId = value;
            OnPropertyChanged(nameof(SelectedId));
        }
    }

   
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

