using Wuzh.Enums;

namespace Wuzh.Models;

public class Function
{
    public string Name { get; }
    public string Filename { get; }

    public List<string> Arguments { get; }
    public List<BasicType> ArgumentsTypes { get; }
    
    public BasicType ReturnType { get; }
    
    public List<WuzhParser.StatementContext> Statements { get; }

    public Function(string name, string filename, 
        List<string> arguments, 
        List<BasicType> argumentsTypes, 
        List<WuzhParser.StatementContext> statements,
        BasicType returnType = BasicType.Any)
    {
        Name = name;
        Filename = filename;
        Arguments = arguments;
        ArgumentsTypes = argumentsTypes;
        Statements = statements;
        ReturnType = returnType;
    }
}