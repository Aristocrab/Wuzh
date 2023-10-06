using Wuzh.Tokens;

namespace Wuzh.MLexer;

public abstract class SyntaxNode { }

public class ProgramNode : SyntaxNode
{
    public List<ImportStatementNode> ImportStatements { get; set; }
    public List<StatementNode> Statements { get; set; }
}

public class ImportStatementNode : SyntaxNode
{
    public string ImportedModule { get; set; }
}

public class StatementNode : SyntaxNode
{
    public SemicolonTerminatedStatementNode? SemicolonTerminatedStatement { get; set; }
    public BraceTerminatedStatementNode? BraceTerminatedStatement { get; set; }
}

public class SemicolonTerminatedStatementNode : SyntaxNode
{
    public DeclarationNode? Declaration { get; set; }
    public AssignmentNode? Assignment { get; set; }
    public IndexAssignmentNode? IndexAssignment { get; set; }
    public FunctionCallNode? FunctionCall { get; set; }
    public ReturnNode? Return { get; set; }
}

public class BraceTerminatedStatementNode : SyntaxNode
{
    public SyntaxNode Statement { get; set; }
}

public class DeclarationNode : SyntaxNode
{
    public bool IsConstant { get; set; }
    public Token Identifier { get; set; }
    public ExpressionNode Expression { get; set; }
}

public class AssignmentNode : SyntaxNode
{
    public Token Identifier { get; set; }
    public SyntaxNode Expression { get; set; }
}

public class IndexAssignmentNode : SyntaxNode
{
    public Token Identifier { get; set; }
    public SyntaxNode Index { get; set; }
    public SyntaxNode Expression { get; set; }
}

public class FunctionCallNode : SyntaxNode
{
    public Token Identifier { get; set; }
    public List<SyntaxNode> Arguments { get; set; }
}

public class ReturnNode : SyntaxNode
{
    public SyntaxNode Expression { get; set; }
}

public class IfStatementNode : SyntaxNode
{
    public SyntaxNode Condition { get; set; }
    public List<StatementNode> Body { get; set; }
    public List<StatementNode>? ElseBody { get; set; }
}

public class WhileStatementNode : SyntaxNode
{
    public SyntaxNode Condition { get; set; }
    public List<StatementNode> Body { get; set; }
}

public class ForStatementNode : SyntaxNode
{
    public DeclarationNode Initialization { get; set; }
    public SyntaxNode Condition { get; set; }
    public AssignmentNode Iteration { get; set; }
    public List<StatementNode> Body { get; set; }
}

public class ForEachStatementNode : SyntaxNode
{
    public Token Variable { get; set; }
    public ExpressionNode Collection { get; set; }
    public List<StatementNode> Body { get; set; }
}

public class FunctionDeclarationNode : SyntaxNode
{
    public Token Identifier { get; set; }
    public List<Token> Parameters { get; set; }
    public List<StatementNode> Body { get; set; }
}

public class ExpressionNode : SyntaxNode
{
    public bool ExclamationMark { get; set; }
    public MultiplyExpressionNode[] MultiplyExpression { get; set; }
    public Token[]? Plus { get; set; }
    public Token[]? Minus { get; set; }
    public ComparisonRightSideNode? ComparisonRightSide { get; set; }
}

public class MultiplyExpressionNode : SyntaxNode
{
    public ValueNode[] Value { get; set; }
    public Token[]? Multiply { get; set; }
    public Token[]? Divide { get; set; }
    public Token[]? FloorDivide { get; set; }
    public Token[]? Remainder { get; set; }
}

public class ValueNode : SyntaxNode
{
    public Token? Minus { get; set; }
    public Token? Identificator { get; set; }
    public FunctionCallNode? FunctionCall { get; set; }
    public BasicTypeValueNode? BasicTypeValue { get; set; }
    public ArrayIndexingNode? ArrayIndexing { get; set; }
    public ExpressionNode? Expression { get; set; } // (expresion)
}

public class ComparisonRightSideNode : SyntaxNode
{
    public ComparisonSignNode ComparisonSign { get; set; }
    public ExpressionNode Expression { get; set; }
}

public class ComparisonSignNode : SyntaxNode
{
    public Token? GreaterThan { get; set; }
    public Token? GreaterThanOrEqual { get; set; }
    public Token? LessThan { get; set; }
    public Token? LessThanOrEqual { get; set; }
    public Token? Equal { get; set; }
    public Token? NotEqual { get; set; }
}

public class BasicTypeValueNode : SyntaxNode
{
    public Token? Unit { get; set; }
    public Token? Integer { get; set; }
    public Token? Double { get; set; }
    public Token? String { get; set; }
    public Token? Boolean { get; set; }
    public ArrayNode? Array { get; set; }
    public RangeNode? Range { get; set; }
    public DictionaryNode? Dictionary { get; set; }
}

public class ArrayIndexingNode : SyntaxNode
{
    public ArrayOrVariableNode ArrayOrVariable { get; set; }
    public IndexNode Index { get; set; }
}

public class ArrayOrVariableNode : SyntaxNode
{
    public Token? Identificator { get; set; }
    public ArrayNode? Array { get; set; }
}

public class IndexNode : SyntaxNode
{
    public ExpressionNode? Expression { get; set; }
    public Token? Identificator { get; set; }
}

public class ArrayNode : SyntaxNode
{
    public List<ExpressionNode> Expressions { get; set; }
}

public class RangeNode : SyntaxNode
{
    public ExpressionNode? Start { get; set; }
    public ExpressionNode? End { get; set; }
}

public class DictionaryNode : SyntaxNode
{
    public List<DictionaryEntryNode> Entries { get; set; }
}

public class DictionaryEntryNode : SyntaxNode
{
    public Token Key { get; set; }
    public ExpressionNode Value { get; set; }
}