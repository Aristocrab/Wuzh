using Moist.Models;

namespace Moist.StandardLibrary;

public static class Functions
{
    public static Unit PrintLine(object value)
    {
        if (value is List<object> list)
        {
            Console.WriteLine($"[{string.Join(", ", list)}]");
        }
        else
        {
            Console.WriteLine(value);
        }
        
        return Unit.Value;
    }
    
    public static Unit PrintLine()
    {
        Console.WriteLine();
        
        return Unit.Value;
    }
    
    public static Unit Print(object value)
    {
        if (value is List<object> list)
        {
            Console.Write($"[{string.Join(", ", list)}]");
        }
        else
        {
            Console.Write(value);
        }
        
        return Unit.Value;
    }
    
    public static string ReadLine()
    {
        return Console.ReadLine() ?? "";
    }

    public static string TypeOf(object obj)
    {
        return MoistVisitor.GetBasicType(obj).ToString();
    }
    
    public static Unit Sleep(int milliseconds)
    {
        Thread.Sleep(milliseconds);
        
        return Unit.Value;
    }
    
    public static string String(object obj)
    {
        return obj.ToString() ?? "";
    }

    public static int Pow(int x, int y)
    {
        return (int)Math.Pow(x, y);
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
    
    public static int Length(string str) // todo
    {
        return str.Length;
    }
    
    public static List<object> Array(int size)
    {
        var arrayOfUnits = new Unit[size];

        for (var i = 0; i < arrayOfUnits.Length; i++)
        {
            arrayOfUnits[i] = Unit.Value;
        }
        
        return new List<object>(arrayOfUnits);
    }
    
    public static List<object> Array(int size, object value)
    {
        var arrayOfUnits = new object[size];

        for (var i = 0; i < arrayOfUnits.Length; i++)
        {
            arrayOfUnits[i] = value;
        }
        
        return new List<object>(arrayOfUnits);
    }
    
    public static int AsciiCode(string c)
    {
        return c[0];
    }
    
    public static string Char(int c)
    {
        return ((char)c).ToString();
    }
}