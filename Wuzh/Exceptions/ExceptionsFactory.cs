using Wuzh.Enums;

namespace Wuzh.Exceptions;

public class ExceptionsFactory
{
    public string Input { get; set; }
    public string FileName { get; set; }

    public ExceptionsFactory(string input, string filename)
    {
        Input = input;
        FileName = filename;
    }
    
    public InterpreterException VariableAlreadyDeclared(string variableName, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Variable '{variableName}' already declared");
        return exception;
    }
    
    public InterpreterException VariableNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Variable '{variableName}' not declared");
        return exception;
    }
    
    public InterpreterException UnknownOperator(string op, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Error: Unknown operator '{op}'");
        return exception;
    }
    
    public InterpreterException ImportFileNotFound(string fileName, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Import file '{fileName}' not found");
        return exception;
    }
    
    public InterpreterException OperatorNotSupportedForNotIntOrDoubleValues(string op, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Operator '{op}' not supported for not int or double values");
        return exception;
    }
    
    public InterpreterException FunctionAlreadyDeclared(string functionName, int argumentsCount, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Function '{functionName}' with {argumentsCount} argument{(argumentsCount == 1 ? "" : "s")} already declared");
        return exception;
    }

    public InterpreterException ReturnOutsideFunction(int line, int column)
    {
        var exception = BuildInterpreterException(line, column, "Return outside function");
        return exception;
    }
    
    public InterpreterException FunctionNotDeclaredWithArgumentTypes(string functionName, IEnumerable<BasicType> argumentTypes, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, 
            $"Function '{functionName}' with arguments ('{string.Join(", '", argumentTypes)}') was not found");
        return exception;
    }
    
    public InterpreterException DifferentTypesComparison(string leftType, string rightType, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Cannot compare '{leftType}' with '{rightType}'");
        return exception;
    }
    
    public InterpreterException ForLoopVariableNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"For loop variable '{variableName}' not declared");
        return exception;
    }
    
    public InterpreterException ForLoopConditionNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"For loop condition variable '{variableName}' not declared");
        return exception;
    }
    
    public InterpreterException UnsupportedTypeAsCollection(string type, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Unsupported type '{type}' as collection");
        return exception;
    }

    public InterpreterException ForLoopStepNotDeclared(string variableName, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"For loop step variable '{variableName}' not declared");
        return exception;
    }

    public InterpreterException GlobalVariableWithSameNameAlreadyDeclared(string parameterName, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Global variable with name '{parameterName}' already declared");
        return exception;
    }

    public InterpreterException DictionaryDoesNotContainKey(string key, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Dictionary does not contain key \"{key}\"");
        return exception;
    }
    
    public InterpreterException DictionaryIndexerMustBeString(BasicType type, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Dictionary indexer must be string, but was '{type}'");
        return exception;
    }
    
    public InterpreterException ReservedWord(string word, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Reserved word '{word}'");
        return exception;
    }
    
    public InterpreterException ExpressionIsNotBoolean(string expression, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Expression '{expression}' is not boolean");
        return exception;
    }
    
    public InterpreterException ValueOfTypeCanNotBeAssigned(BasicType variableType, BasicType assignType, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Value of type '{assignType}' can not be assigned to variable of type '{variableType}'");
        return exception;
    }
    
    public InterpreterException OperatorNotSupportedForTypes(string op, BasicType leftType, BasicType rightType, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Operator '{op}' not supported for types '{leftType}' and '{rightType}'");
        return exception;
    }
    
    public InterpreterException RangeItemMustBeInteger(int line, int column)
    {
        var exception = BuildInterpreterException(line, column, "Range item must be integer");
        return exception;
    }
    
    public InterpreterException RangeStartMustBeLessThanEnd(int line, int column)
    {
        var exception = BuildInterpreterException(line, column, "Range start must be less than end");
        return exception;
    }
    
    public InterpreterException ArrayIndexerMustBeInteger(BasicType type, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Array indexer must be integer, but was '{type}'");
        return exception;
    }
    
    public InterpreterException CanNotAssignToConstant(string constantName, int line, int column)
    {
        var exception = BuildInterpreterException(line, column, $"Cannot assign value to constant variable '{constantName}'");
        return exception;
    }

    public InterpreterException DivisionByZero(int line, int column)
    {
        var exception = BuildInterpreterException(line, column, "Division by zero");
        return exception;
    }

    public LexerException LexerException(int line, int column, string message)
    {
        var exception = BuildInterpreterException(line, column, message);
        var lexerException = new LexerException(exception.Message.Replace("Error", "LexerError"));
        return lexerException;
    }

    public ParserException ParserException(int line, int column, string message)
    {
        if (line != 1 && column == 0)
        {
            line -= 1;
            column = Input.Split('\n')[line-1].Length - 1;
        }

        message = message.Replace("extraneous input '<EOF>'", "");
        message = message.Replace("mismatched input", "before");
        message = message.Replace("expecting {'const', 'func', '}', 'if', 'return', 'while', 'for', Identificator}",
            "expecting '}'");
        message = message.Replace("expecting {'[', '(', 'unit', Boolean, Integer, Double, String, '-', '!', Identificator}",
            "expecting value");
        
        var exception = BuildInterpreterException(line, column, message);
        var parserException = new ParserException(exception.Message.Replace("Error", "ParserError"));
        return parserException;
    }

    public InterpreterException IndexOutOfRangeException(int line, int column)
    {
        var exception = BuildInterpreterException(line, column, "Index out of range");
        return exception;
    }

    private InterpreterException BuildInterpreterException(int line, int column, string message)
    {
        var mess = GetLineWithErrorPosition(line, column, Input);
        mess += $"File: \"{FileName}\" ({line}:{column})\nError: {message}.";
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
        foreach (var t in lineText)
        {
            if (t == ' ')
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