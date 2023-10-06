using System.Text;
using Wuzh.Models;

namespace Wuzh.StandardLibrary;

public static class PrintExtensions
{
    public static string ToWuzhString(this object obj)
    {
        var str =  obj switch
        {
            Unit => "unit",
            string s => s,
            List<object> list => GetListString(list),
            Dictionary<string, object> dict => GetDictionaryString(dict),
            _ => obj.ToString()!
        };
        
        return str;
    }

    private static string GetListString(List<object> list)
    {
        var sb = new StringBuilder();
        
        sb.Append('[');

        foreach (var elem in list)
        {
            if (elem is string str)
            {
                sb.Append($"\"{str}\"");
            }
            else
            {
                 sb.Append(elem);
            }
            
            sb.Append(", ");
        }
        
        sb.Remove(sb.Length - 2, 2);
        sb.Append(']');
        
        return sb.ToString();
    }

    private static string GetDictionaryString(Dictionary<string, object> dictionary)
    {
        var sb = new StringBuilder();
        
        sb.Append('{');

        foreach (var (key, value) in dictionary)
        {
            if (value is string str)
            {
                sb.Append($"{key}: \"{str}\"");
            }
            else
            {
                sb.Append($"{key}: {value}");
            }
            
            sb.Append(", ");
        }
        
        sb.Remove(sb.Length - 2, 2);
        sb.Append('}');
        
        return sb.ToString();
    }
}