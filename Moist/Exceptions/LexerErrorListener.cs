using Antlr4.Runtime;

namespace Moist.Exceptions;

public class LexerErrorListener : IAntlrErrorListener<int>
{
    private readonly string _input;

    public LexerErrorListener(string input)
    {
        _input = input;
    }

    public void SyntaxError(IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg,
        RecognitionException e)
    {
        var mess = InterpreterExceptionsFactory.GetLineWithErrorPosition(line, charPositionInLine, _input);
        mess += $"({line}:{charPositionInLine}) Error: ";
        
        var token = msg
            .Replace("token recognition error at: ", "")
            .Replace("'", "")
            .Replace(";", "");
        
        if (TryRecognizeToken(token, out var message))
        {
            mess += message;
        }
        else
        {
            mess += $"token '{token}' was not recognized";
        }
        
        throw new InterpreterException(mess + ".");
    }

    private static bool TryRecognizeToken(string token, out string message)
    {
        if (token.StartsWith("\"") && token.Count(x => x == '"') == 1)
        {
            // stiring with no second " 
            message = "string literal was not closed. Expected '\"' at the end of the string";
            return true;
        }

        message = "";
        return false;
    }
}