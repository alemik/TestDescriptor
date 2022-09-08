using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TestDescriptor;
public class CustomObject : ICustomTypeDescriptor
{
    private Dictionary<string, string> valuesContainer;

    public CustomObject(Dictionary<string, string> values)
    {
        valuesContainer = values;
    }


    public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
    {
        List<PropertyDescriptor> props = new List<PropertyDescriptor>();

        // Make Attribute array
        Attribute[] attrArray = new Attribute[0];

        // Create and add PropertyDescriptors
        foreach (string key in valuesContainer.Keys)
        {
            CustomPropertyDescriptor pd = new CustomPropertyDescriptor(valuesContainer, key, attrArray);
            props.Add(pd);
        }

        return new PropertyDescriptorCollection(props.ToArray());
    }

    public object GetPropertyOwner(PropertyDescriptor pd)
    {
        return this;
    }

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
    {
        return GetProperties(new Attribute[0]);
    }


    #region base
    public AttributeCollection GetAttributes()
    {
        return TypeDescriptor.GetAttributes(this);
    }

    public string GetClassName()
    {
        return TypeDescriptor.GetClassName(this);
    }

    public string GetComponentName()
    {
        return TypeDescriptor.GetComponentName(this);
    }

    public TypeConverter GetConverter()
    {
        return TypeDescriptor.GetConverter(this);
    }

    public EventDescriptor GetDefaultEvent()
    {
        return TypeDescriptor.GetDefaultEvent(this);
    }

    public PropertyDescriptor GetDefaultProperty()
    {
        return TypeDescriptor.GetDefaultProperty(this);
    }

    public object GetEditor(Type editorBaseType)
    {
        return null;
    }

    public EventDescriptorCollection GetEvents()
    {
        return TypeDescriptor.GetEvents(this);
    }

    public EventDescriptorCollection GetEvents(Attribute[] attributes)
    {
        return TypeDescriptor.GetEvents(this, attributes);
    }
    #endregion

}
