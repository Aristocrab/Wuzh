using Moist.Enums;

namespace Moist.Exceptions;

public class InterpreterExceptionsFactory
{
    private readonly string _input;

    public InterpreterExceptionsFactory(string input)
    {
        _input = input;
    }
    
    public InterpreterException VariableAlreadyDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Variable '{variableName}' already declared");
        return exception;
    }
    
    public InterpreterException VariableNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Variable '{variableName}' not declared");
        return exception;
    }
    
    public InterpreterException UnknownOperator(string op, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Error: Unknown operator '{op}'");
        return exception;
    }
    
    public InterpreterException FunctionAlreadyDeclared(string functionName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Function '{functionName}' already declared");
        return exception;
    }
    
    public InterpreterException FunctionNotDeclared(string functionName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Function '{functionName}' was not found");
        return exception;
    }
    
    public InterpreterException FunctionNotDeclaredWithArgumentTypes(string functionName, IEnumerable<BasicType> argumentTypes, int line, int column)
    {
        var exception = BuildParserException(line, column, 
            $"Function '{functionName}' with arguments ('{string.Join(", '", argumentTypes)}') was not found");
        return exception;
    }
    
    public InterpreterException DifferentTypesComparison(string leftType, string rightType, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Cannot compare '{leftType}' with '{rightType}'");
        return exception;
    }
    
    public InterpreterException ForLoopVariableNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"For loop variable '{variableName}' not declared");
        return exception;
    }
    
    public InterpreterException ForLoopConditionNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"For loop condition variable '{variableName}' not declared");
        return exception;
    }
    
    public InterpreterException UnsupportedTypeAsCollection(string type, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Unsupported type '{type}' as collection");
        return exception;
    }
    
    public InterpreterException UnknownType(string type, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Unknown type '{type}'");
        return exception;
    }
    
    public InterpreterException ForLoopStepNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"For loop step variable '{variableName}' not declared");
        return exception;
    }
    
    public InterpreterException BoolTypeComparisonWrongOperator(string op, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Cannot use operator '{op}' with boolean type");
        return exception;
    }

    public InterpreterException GlobalVariableWithSameNameAlreadyDeclared(string parameterName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Global variable with name '{parameterName}' already declared");
        return exception;
    }
    
    public InterpreterException ExpressionIsNotBoolean(string expression, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Expression '{expression}' is not boolean");
        return exception;
    }
    
    public InterpreterException ValueOfTypeCanNotBeAssigned(BasicType variableType, BasicType assignType, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Value of type '{assignType}' can not be assigned to variable of type '{variableType}'");
        return exception;
    }
    
    public InterpreterException OperatorNotSupportedForTypes(string op, BasicType leftType, BasicType rightType, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Operator '{op}' not supported for types '{leftType}' and '{rightType}'");
        return exception;
    }
    
    public InterpreterException ArrayIndexerMustBeInteger(BasicType type, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Array indexer must be integer, but was '{type}'");
        return exception;
    }
    
    public InterpreterException CanNotAssignToConstant(string constantName, int line, int column)
    {
        var exception = BuildParserException(line, column, $"Cannot assign value to constant variable '{constantName}'");
        return exception;
    }

    private InterpreterException BuildParserException(int line, int column, string message)
    {
        var mess = GetLineWithErrorPosition(line, column, _input);
        mess += $"({line}:{column}) Error: {message}.";
        return new InterpreterException(mess);
    }
    
    public static string GetLineWithErrorPosition(int line, int column, string input)
    {
        string lineText;
        if (line == 0)
        {
            lineText = input.Split('\n')[0];
        }
        else
        {
            lineText = input.Split('\n')[line - 1];
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