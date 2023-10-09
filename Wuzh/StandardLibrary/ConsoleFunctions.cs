using Wuzh.Models;

namespace Wuzh.StandardLibrary;

public static class ConsoleFunctions
{
    public static Unit PrintLine(params object[] values)
    {
        var str = string.Join(", ", values.Select(v => v.ToWuzhString()));
        Console.WriteLine(str);
        
        return Unit.Value;
    }
    
    public static Unit PrintLine()
    {
        Console.WriteLine();
        
        return Unit.Value;
    }
    
    public static Unit Print(params object[] values)
    {
        var str = string.Join(", ", values.Select(v => v.ToWuzhString()));
        Console.Write(str);
        
        return Unit.Value;
    }
    
    public static string ReadLine()
    {
        return Console.ReadLine() ?? "";
    }
    
    public static Unit Clear()
    {
        Console.Clear();
        return Unit.Value;
    }
    
    public static Unit DisableCursor(bool disable)
    {
        Console.CursorVisible = !disable;
        return Unit.Value;
    }
}