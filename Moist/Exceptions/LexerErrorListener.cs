using Antlr4.Runtime;

namespace Moist.Exceptions;

public class LexerErrorListener : IAntlrErrorListener<int>
{
    private readonly string _input;

    public LexerErrorListener(string input)
    {
        _input = input;
    }
    
    public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine,
        string msg, RecognitionException e)
    {
        var mess = InterpreterExceptionsFactory.GetLineWithErrorPosition(line, charPositionInLine, _input);
        
        var token = msg.Replace("token recognition error at: ", "");
        mess += $"({line}:{charPositionInLine}) Error: token {token} was not recognized";
        
        throw new InterpreterException(mess);
    }
}