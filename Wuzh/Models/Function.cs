namespace Wuzh.Models;

public class Function
{
    public string Name { get; }
    public string Filename { get; }

    public List<string> Arguments { get; }
    
    public List<WuzhParser.StatementContext> Statements { get; }

    public Function(string name, string filename, List<string> arguments, List<WuzhParser.StatementContext> statements)
    {
        Name = name;
        Filename = filename;
        Arguments = arguments;
        Statements = statements;
    }
}