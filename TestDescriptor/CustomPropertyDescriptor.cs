using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TestDescriptor;
public class CustomPropertyDescriptor : PropertyDescriptor
{
    private Dictionary<string, string> valuesContainer;

    public CustomPropertyDescriptor(Dictionary<string, string> valuesContainer, string name, Attribute[] attrs) : base(name, attrs)
    {
        this.valuesContainer = valuesContainer;
    }

    public override Type ComponentType
    {
        get { return typeof(CustomObject); }
    }

    public override bool IsReadOnly
    {
        get { return false; }
    }

    public override Type PropertyType
    {
        get { return typeof(string); }
    }

    public override bool CanResetValue(object component)
    {
        return (GetValue(component).Equals("") == false);
    }

    public override void ResetValue(object component)
    {
        SetValue(component, "");
    }

    public override bool ShouldSerializeValue(object component)
    {
        return false;
    }

    public override object GetValue(object component)
    {
        return valuesContainer[Name];
    }

    public override void SetValue(object component, object value)
    {
        valuesContainer[Name] = value.ToString();
    }
}
