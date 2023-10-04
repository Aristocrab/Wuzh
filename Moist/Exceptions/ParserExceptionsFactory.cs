using Moist.Enums;

namespace Moist.Exceptions;

public class ParserExceptionsFactory
{
    private readonly string _input;

    public ParserExceptionsFactory(string input)
    {
        _input = input;
    }
    
    public ParserException VariableAlreadyDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Variable '{variableName}' already declared");
        return exception;
    }
    
    public ParserException VariableNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Variable '{variableName}' not declared");
        return exception;
    }
    
    public ParserException UnknownOperator(string op, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Error: Unknown operator '{op}'");
        return exception;
    }
    
    public ParserException FunctionAlreadyDeclared(string functionName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Function '{functionName}' already declared");
        return exception;
    }
    
    public ParserException FunctionNotDeclared(string functionName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Function '{functionName}' was not found");
        return exception;
    }
    
    public ParserException FunctionNotDeclaredWithArgumentTypes(string functionName, IEnumerable<BasicType> argumentTypes, int line, int column)
    {
        var exception = BuildParserException(line, column, 
            $"Function '{functionName}' with arguments ('{string.Join(", '", argumentTypes)}') was not found");
        return exception;
    }
    
    public ParserException DifferentTypesComparison(string leftType, string rightType, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Cannot compare '{leftType}' with '{rightType}'");
        return exception;
    }
    
    public ParserException ForLoopVariableNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"For loop variable '{variableName}' not declared");
        return exception;
    }
    
    public ParserException ForLoopConditionNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"For loop condition variable '{variableName}' not declared");
        return exception;
    }
    
    public ParserException UnsupportedTypeAsCollection(string type, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Unsupported type '{type}' as collection");
        return exception;
    }
    
    public ParserException UnknownType(string type, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Unknown type '{type}'");
        return exception;
    }
    
    public ParserException ForLoopStepNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"For loop step variable '{variableName}' not declared");
        return exception;
    }
    
    public ParserException BoolTypeComparisonWrongOperator(string op, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Cannot use operator '{op}' with boolean type");
        return exception;
    }

    public ParserException GlobalVariableWithSameNameAlreadyDeclared(string parameterName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Global variable with name '{parameterName}' already declared");
        return exception;
    }
    
    public ParserException ExpressionIsNotBoolean(string expression, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Expression '{expression}' is not boolean");
        return exception;
    }
    
    public ParserException ValueOfTypeCanNotBeAssigned(BasicType variableType, BasicType assignType, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Value of type '{assignType}' can not be assigned to variable of type '{variableType}'");
        return exception;
    }
    
    public ParserException OperatorNotSupportedForTypes(string op, BasicType leftType, BasicType rightType, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Operator '{op}' not supported for types '{leftType}' and '{rightType}'");
        return exception;
    }
    
    public ParserException ArrayIndexerMustBeInteger(BasicType type, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Array indexer must be integer, but was '{type}'");
        return exception;
    }
    
    public ParserException CanNotAssignToConstant(string constantName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Cannot assign value to constant variable '{constantName}'");
        return exception;
    }

    private ParserException BuildParserException(int line, int column, string message)
    {
        var mess = GetLineWithErrorPosition(line, column);
        mess += $"({line}:{column}) Error: {message}.";
        return new ParserException(mess);
    }
    
    private string GetLineWithErrorPosition(int line, int column)
    {
        string lineText;
        if (line == 0)
        {
            lineText = _input.Split('\n')[0];
        }
        else
        {
            lineText = _input.Split('\n')[line - 1];
        }
        
        var spacesAtStart = 0;
        for (var i = 0; i < lineText.Length; i++)
        {
            if (lineText[i] == ' ')
            {
                spacesAtStart++;
            }
            else
            {
                break;
            }
        }
        
        column -= spacesAtStart;
        lineText = lineText.TrimStart();
        
        var ret = lineText + '\n';
        for (var i = 0; i < column; i++)
        {
            ret += ' ';
        }
        ret += "^\n";
        return ret;
    }
}