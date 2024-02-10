using Wuzh.Models;

namespace Wuzh.StandardLibrary;

public static class ArrayFunctions
{
    public static List<object> Array(int size)
    {
        var arrayOfUnits = new Unit[size];

        for (var i = 0; i < arrayOfUnits.Length; i++)
        {
            arrayOfUnits[i] = Unit.Value;
        }
        
        return [..arrayOfUnits];
    }
    
    public static List<object> Array(int size, object defaultValue)
    {
        var arrayOfUnits = new object[size];

        for (var i = 0; i < arrayOfUnits.Length; i++)
        {
            arrayOfUnits[i] = defaultValue;
        }
        
        return [..arrayOfUnits];
    }
    
    public static Unit Append(List<object> list, object value)
    {
        list.Add(value);
        
        return Unit.Value;
    }
    
    public static Unit SetValue(List<object> list, int index, object value)
    {
        list[index] = value;
        
        return Unit.Value;
    }
    
    public static Unit Remove(List<object> list, int index)
    {
        list.RemoveAt(index);
        
        return Unit.Value;
    }
    
    public static Unit Clear(List<object> list)
    {
        list.Clear();
        
        return Unit.Value;
    }
    
    public static int Length(List<object> list)
    {
        return list.Count;
    }
}