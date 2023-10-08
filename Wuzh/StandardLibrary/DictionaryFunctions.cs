namespace Wuzh.StandardLibrary;

public static class DictionaryFunctions
{
    public static bool Contains(Dictionary<string, object> dict, string key)
    {
        return dict.ContainsKey(key);
    }
    
    public static List<object> GetKeys(Dictionary<string, object> dict)
    {
        return dict.Keys.Select(x => (object)x).ToList();
    }
    
    public static List<object> GetValues(Dictionary<string, object> dict)
    {
        return dict.Values.Select(x => x).ToList();
    }
}