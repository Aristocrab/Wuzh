namespace Moist.Models;

public class Function
{
    public string Name { get; }
    
    public List<string> Arguments { get; }
    
    public List<MoistParser.StatementContext> Statements { get; }

    public Function(string name, List<string> arguments, List<MoistParser.StatementContext> statements)
    {
        Name = name;
        Arguments = arguments;
        Statements = statements;
    }
}