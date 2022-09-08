using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace TestDescriptor;
public class ObservableObject : INotifyPropertyChanged
{

    public virtual event PropertyChangedEventHandler PropertyChanged;

    [DebuggerHidden()]
    public virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
