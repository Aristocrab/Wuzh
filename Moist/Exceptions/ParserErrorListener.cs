using Antlr4.Runtime;

namespace Moist.Exceptions;

public class ParserErrorListener : IAntlrErrorListener<IToken>
{
    private readonly string _input;

    public ParserErrorListener(string input)
    {
        _input = input;
    }
    
    public void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine,
        string msg, RecognitionException e)
    {
        var mess = InterpreterExceptionsFactory.GetLineWithErrorPosition(line, charPositionInLine, _input);

        if (msg.Contains("missing"))
        {
            msg = msg.Replace("at", "before");
        }
        
        mess += $"({line}:{charPositionInLine}) Error: {msg}";
        
        throw new InterpreterException(mess);
    }
}