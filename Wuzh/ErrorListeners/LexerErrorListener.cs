using Antlr4.Runtime;
using Wuzh.Exceptions;

namespace Wuzh.ErrorListeners;

public class LexerErrorListener : IAntlrErrorListener<int>
{
    private readonly ExceptionsFactory _exceptionsFactory;

    public LexerErrorListener(ExceptionsFactory exceptionsFactory)
    {
        _exceptionsFactory = exceptionsFactory;
    }

    public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg,
        RecognitionException e)
    {
        var mess = "";
        
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
        
        throw _exceptionsFactory.LexerException(line, charPositionInLine, mess);
    }

    private static bool TryRecognizeToken(string token, out string message)
    {
        if (token.StartsWith('"') && token.Count(x => x == '"') == 1)
        {
            // stiring with no second " 
            message = "string literal was not closed. Expected '\"' at the end of the string";
            return true;
        }

        message = "";
        return false;
    }
}