namespace Wuzh.Tokens;

public class Token
{
    public int TokenLength { get; }
    public TokenType Type { get; }
    public string Text { get; }
    public int Line { get; }
    public int Column { get; }
    
    public Token(TokenType type, string text, int line, int column, int tokenLength)
    {
        TokenLength = tokenLength;
        Type = type;
        Text = text;
        Line = line;
        Column = column;
    }

    public override string ToString()
    {
        return $"<{Type}, {Text}> at {Line}:{Column} ({TokenLength} chars)";
    }
}