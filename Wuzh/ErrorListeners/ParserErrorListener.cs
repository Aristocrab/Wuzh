using Antlr4.Runtime;
using Wuzh.Exceptions;

namespace Wuzh.ErrorListeners;

public class ParserErrorListener : IAntlrErrorListener<IToken>
{
    private readonly ExceptionsFactory _exceptionsFactory;

    public ParserErrorListener(ExceptionsFactory exceptionsFactory)
    {
        _exceptionsFactory = exceptionsFactory;
    }

    public void SyntaxError(TextWriter textWriter, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg,
        RecognitionException e)
    {
        if (msg.Contains("missing"))
        {
            msg = msg.Replace("at", "before");
            msg = msg.Replace("before '<EOF>'", "at the end of the file");
        }

        if (msg.Contains("expecting") && !msg.Contains("extraneous"))
        {
            var firstQuotePosition = msg.IndexOf('\'') + 1;
            var lastQuotePosition = msg.LastIndexOf('\'');
            var keyWord = msg[firstQuotePosition..lastQuotePosition];
            msg = $"can't use keyword '{keyWord}' in this context";
        }
        if (msg.Contains("expecting") && msg.Contains("extraneous"))
        {
            var firstQuotePosition = msg.IndexOf('\'') + 1;
            var secondQuotePosition = msg.IndexOf('\'', firstQuotePosition);
            var thirdQuotePosition = msg.IndexOf('\'', secondQuotePosition + 1);
            var lastQuotePosition = msg.LastIndexOf('\'');
            var keyWord = msg[firstQuotePosition..secondQuotePosition];
            var expectedKeyWord = msg[thirdQuotePosition..lastQuotePosition];
            msg = $"expected {expectedKeyWord}' instead of '{keyWord}'";
        }
        
        throw _exceptionsFactory.ParserException(line, charPositionInLine, msg);
    }
}