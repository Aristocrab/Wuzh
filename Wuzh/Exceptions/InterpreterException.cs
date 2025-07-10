namespace Wuzh.Exceptions;

public class InterpreterException : Exception
{
    public InterpreterException(string message) : base(message) { }

    public InterpreterException() { }

    public InterpreterException(string? message, Exception? innerException) : base(message, innerException) { }
}