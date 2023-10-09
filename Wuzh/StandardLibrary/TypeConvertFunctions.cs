namespace Wuzh.StandardLibrary;

public static class TypeConvertFunctions
{
    public static string ToString(object obj)
    {
        return obj.ToWuzhString();
    }
    
    public static int AsciiCode(string c)
    {
        return c[0];
    }
    
    public static string IntAsAscii(int c)
    {
        return ((char)c).ToString();
    }
    
    public static string IntToString(int c)
    {
        return c.ToString();
    }

    public static int StringToInt(string str)
    {
        return int.Parse(str);
    }
    
    public static string DoubleToString(decimal c)
    {
        return c.ToWuzhString();
    }

    public static decimal StringToDouble(string str)
    {
        return decimal.Parse(str);
    }
    
    public static decimal IntToDouble(int num)
    {
        return num;
    }
    
    public static int DoubleToInt(decimal num)
    {
        return (int)num;
    }
}