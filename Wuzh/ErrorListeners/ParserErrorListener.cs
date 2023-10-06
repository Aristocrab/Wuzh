using Antlr4.Runtime;
using Wuzh.Exceptions;

namespace Wuzh.ErrorListeners;

public class ParserErrorListener : IAntlrErrorListener<IToken>
{
    private readonly string _input;
    private readonly ExceptionsFactory _exceptionsFactory;

    public ParserErrorListener(string input, ExceptionsFactory exceptionsFactory)
    {
        _input = input;
        _exceptionsFactory = exceptionsFactory;
    }

    public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
        RecognitionException e)
    {
        if (msg.Contains("missing"))
        {
            msg = msg.Replace("at", "before");
            msg = msg.Replace("before '<EOF>'", "at the end of the file");
        }
        
        throw _exceptionsFactory.ParserException(line, charPositionInLine, msg);
    }
}