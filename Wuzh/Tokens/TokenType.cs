using System.Reflection;
using Ardalis.SmartEnum;

namespace Wuzh.Tokens;

public class TokenType : SmartEnum<TokenType, string>
{
    public static readonly TokenType Unit = new(nameof(Unit), "unit");
    public static readonly TokenType Boolean = new(nameof(Boolean), "true|false");
    public static readonly TokenType Double = new(nameof(Double), @"[0-9]+\.[0-9]+");
    public static readonly TokenType Integer = new(nameof(Integer), "(0|[1-9][0-9]*)");
    public static readonly TokenType String = new(nameof(String), "\"([^\"\\\\\\r\\n]|\\\\.)*\"");
        
    public static readonly TokenType Identifier = new(nameof(Identifier), "[a-zA-Z_@][a-zA-Z0-9_]*");
        
    // Declare and assign
    public static readonly TokenType Declare = new(nameof(Declare), ":=");
    public static readonly TokenType Assign = new(nameof(Assign), "=");

    // Symbols
    public static readonly TokenType LeftParenthesis = new(nameof(LeftParenthesis), "\\(");
    public static readonly TokenType RightParenthesis = new(nameof(RightParenthesis), "\\)");
    public static readonly TokenType LeftSquareBracket = new(nameof(LeftSquareBracket), "\\[");
    public static readonly TokenType RightSquareBracket = new(nameof(RightSquareBracket), "\\]");
    public static readonly TokenType LeftCurlyBracket = new(nameof(LeftCurlyBracket), "\\{");
    public static readonly TokenType RightCurlyBracket = new(nameof(RightCurlyBracket), "\\}");
    public static readonly TokenType Comma = new(nameof(Comma), ",");
    public static readonly TokenType Semicolon = new(nameof(Semicolon), ";");
    public static readonly TokenType Colon = new(nameof(Colon), ":");
    public static readonly TokenType TwoDots = new(nameof(TwoDots), @"\.\.");
        
    // Operators
    public static readonly TokenType Plus = new(nameof(Plus), "\\+");
    public static readonly TokenType Minus = new(nameof(Minus), "-");
    public static readonly TokenType Multiply = new(nameof(Multiply), "\\*");
    public static readonly TokenType Divide = new(nameof(Divide), "/");
    public static readonly TokenType FloorDivide = new(nameof(FloorDivide), "//");
    public static readonly TokenType Remainder = new(nameof(Remainder), "%");
    public static readonly TokenType GreaterThan = new(nameof(GreaterThan), ">");
    public static readonly TokenType GreaterThanOrEqual = new(nameof(GreaterThanOrEqual), ">=");
    public static readonly TokenType LessThan = new(nameof(LessThan), "<");
    public static readonly TokenType LessThanOrEqual = new(nameof(LessThanOrEqual), "<=");
    public static readonly TokenType Equal = new(nameof(Equal), "==");
    public static readonly TokenType NotEqual = new(nameof(NotEqual), "!=");
    public static readonly TokenType And = new(nameof(And), "&&");
    public static readonly TokenType Or = new(nameof(Or), "\\|\\|");
    public static readonly TokenType Not = new(nameof(Not), "!");
        
    public static readonly TokenType Whitespaces = new(nameof(Whitespaces), "\\s+");
    public static readonly TokenType Comment = new(nameof(Comment), "#.*");
        
    public string Regex => Value;

    public static List<TokenType> ListAll()
    {
        var type = typeof(TokenType);
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            
        return fields.Select(f => (TokenType)f.GetValue(null)!).ToList();
    }

    private TokenType(string name, string regex) : base(name, regex)
    {
    }
}