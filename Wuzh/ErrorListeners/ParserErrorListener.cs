using Antlr4.Runtime;
<<<<<<<< Updated upstream:Wuzh/Exceptions/ParserErrorListener.cs

namespace Moist.Exceptions;
========
using Wuzh.Exceptions;

namespace Wuzh.ErrorListeners;
>>>>>>>> Stashed changes:Wuzh/ErrorListeners/ParserErrorListener.cs

public class ParserErrorListener : IAntlrErrorListener<IToken>
{
    private readonly string _input;

    public ParserErrorListener(string input)
    {
        _input = input;
    }

    public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
        RecognitionException e)
    {
        var mess = InterpreterExceptionsFactory.GetLineWithErrorPosition(line, charPositionInLine, _input);

        if (msg.Contains("missing"))
        {
            msg = msg.Replace("at", "before");
            msg = msg.Replace("before '<EOF>'", "at the end of the file");
        }
        
        mess += $"({line}:{charPositionInLine}) Error: {msg}.";
        
        throw new InterpreterException(mess);
    }
}