using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDescriptor;
public class ViewModel : ObservableObject
{
    private CustomObject currentItem;
    public CustomObject CurrentItem
    {
        get { return currentItem; }
        set { currentItem = value; NotifyPropertyChanged(); 
    }
}
    public CustomObject person { get; set; }

    public ObservableCollection<CustomObject> Items { get; set; } = new ObservableCollection<CustomObject>();

    public ViewModel()
	{
        var values = new Dictionary<string, string>();
        values.Add("Name", "Mario");
        values.Add("LastName", "Rossi");

        person = new CustomObject(values);

        Items.Add(person);
    }
}
