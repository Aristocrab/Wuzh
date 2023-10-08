using Wuzh.Models;

namespace Wuzh.StandardLibrary;

public static class MainFunctions
{
    public static string TypeOf(object obj)
    {
        return WuzhVisitor.GetBasicType(obj).ToString();
    }
    
    public static Unit Sleep(int milliseconds)
    {
        Thread.Sleep(milliseconds);
        
        return Unit.Value;
    }
}