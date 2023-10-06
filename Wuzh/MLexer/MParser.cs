using Wuzh.Exceptions;
using Wuzh.Tokens;

namespace Wuzh.MLexer;

public class MParser
{
    private readonly IReadOnlyList<Token> _tokens;
    private int Position { get; set; }
    
    // private string Code { get; }

    public MParser(IReadOnlyList<Token> tokens)
    {
        _tokens = tokens;
        Position = 0;
    }

    private Token CurrentToken => _tokens[Position];

    public ProgramNode ParseProgram()
    {
        var program = new ProgramNode
        {
            ImportStatements = new List<ImportStatementNode>(),
            Statements = new List<StatementNode>()
        };

        while (Position < _tokens.Count && CurrentToken.Text == "import")
        {
            program.ImportStatements.Add(ParseImportStatement());
        }

        program.Statements.Add(ParseStatement());

        return program;
    }
    
    public ImportStatementNode ParseImportStatement()
    {
        Require(TokenType.Identifier);
        var filename = Match(TokenType.String);
        Require(TokenType.Semicolon);
        
        if(filename == null)
        {
            throw new ParserException("Expected filename");
        }
        
        var importStatement = new ImportStatementNode
        {
            ImportedModule = filename!.Text
        };

        return importStatement;
    }
    
    public StatementNode ParseStatement()
    {
        var statementNode = new StatementNode();
        
        try
        {
            var st = ParseSemicolonTerminatedStatement();
            Require(TokenType.Semicolon);
            statementNode.SemicolonTerminatedStatement = st;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            // var bt = ParseBraceTerminatedStatement();
            // return new StatementNode
            // {
            //     SemicolonTerminatedStatement = null,
            //     BraceTerminatedStatement = bt
            // };
        }

        return statementNode;
    }

    private SemicolonTerminatedStatementNode ParseSemicolonTerminatedStatement()
    {
        var isConst = Match(TokenType.Identifier);
        if (isConst is not null && isConst.Text != "const")
        {
            Position--;
        }
        
        var st = new SemicolonTerminatedStatementNode();
        var token = Match(TokenType.Identifier);
        if (token == null)
        {
            throw new ParserException("Expected identifier");
        }

        if (token.Text == "return")
        {
            st.Return = ParseReturnStatement();
        }
        
        var nextToken = Match(TokenType.Declare, TokenType.Assign, TokenType.LeftSquareBracket, TokenType.LeftParenthesis);
        if (nextToken == null)
        {
            throw new ParserException("Expected :=, =, ) or }");
        }
        Position -= 2;

        if (nextToken.Type == TokenType.Declare)
        {
            st.Declaration = ParseDeclaration();
        }
        else if (nextToken.Type == TokenType.Assign)
        {
            st.Assignment = ParseAssignment();
        }
        else if (nextToken.Type == TokenType.LeftSquareBracket)
        {
            st.IndexAssignment = ParseIndexAssignment();
        }
        else if (nextToken.Type == TokenType.LeftParenthesis)
        {
            st.FunctionCall = ParseFunctionCall();
        } 
        else if (nextToken.Text == "const")
        {
            Match(TokenType.Identifier);
            if (token == null)
            {
                throw new ParserException("Expected identifier");
            }

            Position--;
            st.Declaration = ParseDeclaration();
        }

        return st;
    }

    private FunctionCallNode ParseFunctionCall()
    {
        var functionCall = new FunctionCallNode();
        functionCall.Identifier = Match(TokenType.Identifier);

        // Parse function call arguments
        Match(TokenType.LeftParenthesis);
        while (CurrentToken.Type != TokenType.RightParenthesis)
        {
            functionCall.Arguments.Add(ParseExpression());
            if (CurrentToken.Type == TokenType.Comma)
            {
                Match(TokenType.Comma);
            }
        }
        Match(TokenType.RightParenthesis);

        return functionCall;
    }

    private IndexAssignmentNode ParseIndexAssignment()
    {
        var indexAssignment = new IndexAssignmentNode();
        indexAssignment.Identifier = Match(TokenType.Identifier);
        Match(TokenType.LeftCurlyBracket);
        indexAssignment.Index = ParseExpression();
        Match(TokenType.RightSquareBracket);
        Match(TokenType.Assign);
        indexAssignment.Expression = ParseExpression();
        return indexAssignment;
    }

    private AssignmentNode ParseAssignment()
    {
        var assignment = new AssignmentNode();
        assignment.Identifier = Match(TokenType.Identifier);
        Match(TokenType.Assign);
        assignment.Expression = ParseExpression();
        return assignment;
    }

    private ReturnNode ParseReturnStatement()
    {
        var returnStatement = new ReturnNode();
        Require(TokenType.Identifier);
        returnStatement.Expression = ParseExpression();
        return returnStatement;
    }

    private DeclarationNode ParseDeclaration()
    {
        var isConst = false;
        if (Position > 0)
        {
            Position--;
            isConst = _tokens[Position].Text == "const";
            Position++;
        }
        
        var declaration = new DeclarationNode();
        var token = Match(TokenType.Identifier);
        if (token == null)
        {
            throw new ParserException("Expected identifier");
        }
        
        declaration.Identifier = token;
        Require(TokenType.Declare);
        declaration.IsConstant = isConst;
        declaration.Expression = ParseExpression();
        return declaration;
    }

    private ExpressionNode ParseExpression()
    {
        var expressionNode = new ExpressionNode();

        var exclamationMark = Match(TokenType.Not);

        MultiplyExpressionNode mult = ParseMultiplyExpression();

        expressionNode.ExclamationMark = exclamationMark is not null;
        expressionNode.MultiplyExpression = (new List<MultiplyExpressionNode>
        {
            mult
        }).ToArray();

        return expressionNode;
    }

    private MultiplyExpressionNode ParseMultiplyExpression()
    {
        var m = new MultiplyExpressionNode();

        ValueNode val = ParseValueNode();
        m.Value = new List<ValueNode>
        {
            val
        }.ToArray();

        return m;
    }

    private ValueNode ParseValueNode()
    {
        var valueNode = new ValueNode();
        
        var token = Match(TokenType.Unit, TokenType.Integer, TokenType.Double, TokenType.Boolean, TokenType.String, TokenType.Identifier);
        if (token is null)
        {
            throw new Exception();
        }

        Position--;
        
        if (token.Type == TokenType.Unit 
            || token.Type == TokenType.Integer
            || token.Type == TokenType.Double
            || token.Type == TokenType.Boolean
            || token.Type == TokenType.String)
        {
            valueNode.BasicTypeValue = ParseBasicValueNode();
        }

        return valueNode;
    }

    private BasicTypeValueNode? ParseBasicValueNode()
    {
        var token = NextToken()!;
        Position++;

        var basicType = new BasicTypeValueNode();

        if (token.Type == TokenType.String)
        {
            basicType.String = token;
        }
        else if (token.Type == TokenType.Integer)
        {
            basicType.Integer = token;
        }
        else if (token.Type == TokenType.Double)
        {
            basicType.Double = token;
        }
        else if (token.Type == TokenType.Boolean)
        {
            basicType.Boolean = token;
        }
        else if (token.Type == TokenType.Unit)
        {
            basicType.Unit = token;
        }

        return basicType;
    }

    private BraceTerminatedStatementNode ParseBraceTerminatedStatement()
    {
        throw new NotImplementedException();
    }
    
    private Token? NextToken()
    {
        if(Position < _tokens.Count)
        {
            return _tokens[Position];
        }

        return null;
    }

    private Token? Match(params TokenType[] expected)
    {
        if(Position < _tokens.Count) 
        {
            var currentToken = _tokens[Position];
            if(expected.Any(type => type.Name == currentToken.Type.Name))
            {
                Position += 1;
                return currentToken;
            }
        } 

        return null;
    }

    private void Require(params TokenType[] expected)
    {
        var token = Match(expected);
        if(token == null)
        {
            throw new ParserException($"Expected one of {string.Join(", ", expected.Select(t => t.Name))}, got {CurrentToken.Type.Name}");
        }
    }
}