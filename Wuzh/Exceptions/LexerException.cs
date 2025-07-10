namespace Wuzh.Exceptions;

public class LexerException : Exception
{
    public LexerException(string message) : base(message) { }

    public LexerException() { }

    public LexerException(string? message, Exception? innerException) : base(message, innerException) { }
}