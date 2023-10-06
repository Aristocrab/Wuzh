using System.Text.RegularExpressions;
using Wuzh.Exceptions;
using Wuzh.Tokens;

namespace Wuzh.MLexer;

public class MLexer
{
    private string Code { get; }
    private int Position { get; set; }
    public List<Token> Tokens { get; private set; } = new();

    public MLexer(string code)
    {
        Code = code;
    }

    public void LexAnalysis()
    {
        while(NextToken())
        { }

        Tokens = Tokens.Where(t => t.Type != TokenType.Whitespaces && t.Type != TokenType.Comment).ToList();
    }

    private bool NextToken()
    {
        if(Position >= Code.Length) return false;

        foreach (var tokenType in TokenType.ListAll())
        {
            var result = Regex.Match(Code[Position..], "^" + tokenType.Regex);

            if (result.Success)
            {
                var line = Code[..Position].Count(c => c == '\n') + 1;
                var column = Position - Code[..Position].LastIndexOf('\n');
                var tokenLength = result.Value.Length;
                var token = new Token(tokenType, result.Value, line, column, tokenLength);
                Position += result.Value.Length;
                Tokens.Add(token);
                return true;
            }
        }

        var match = Regex.Match(Code[Position..], "^\\S+");
        throw new LexerException($"Unexpected token {match.Value}"); // todo
    }
}