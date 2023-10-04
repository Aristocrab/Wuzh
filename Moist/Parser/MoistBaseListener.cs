//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Moist.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419


using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IMoistListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.Diagnostics.DebuggerNonUserCode]
[System.CLSCompliant(false)]
public partial class MoistBaseListener : IMoistListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterProgram([NotNull] MoistParser.ProgramContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.program"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitProgram([NotNull] MoistParser.ProgramContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] MoistParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] MoistParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.semicolonTerminatedStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSemicolonTerminatedStatement([NotNull] MoistParser.SemicolonTerminatedStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.semicolonTerminatedStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSemicolonTerminatedStatement([NotNull] MoistParser.SemicolonTerminatedStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.braceTerminatedStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBraceTerminatedStatement([NotNull] MoistParser.BraceTerminatedStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.braceTerminatedStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBraceTerminatedStatement([NotNull] MoistParser.BraceTerminatedStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDeclaration([NotNull] MoistParser.DeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.declaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDeclaration([NotNull] MoistParser.DeclarationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterAssignment([NotNull] MoistParser.AssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.assignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitAssignment([NotNull] MoistParser.AssignmentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.indexAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIndexAssignment([NotNull] MoistParser.IndexAssignmentContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.indexAssignment"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIndexAssignment([NotNull] MoistParser.IndexAssignmentContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpression([NotNull] MoistParser.ExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.expression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpression([NotNull] MoistParser.ExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.multiplyExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterMultiplyExpression([NotNull] MoistParser.MultiplyExpressionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.multiplyExpression"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitMultiplyExpression([NotNull] MoistParser.MultiplyExpressionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterValue([NotNull] MoistParser.ValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.value"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitValue([NotNull] MoistParser.ValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.comparisonRightSide"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterComparisonRightSide([NotNull] MoistParser.ComparisonRightSideContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.comparisonRightSide"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitComparisonRightSide([NotNull] MoistParser.ComparisonRightSideContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.comparisonSign"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterComparisonSign([NotNull] MoistParser.ComparisonSignContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.comparisonSign"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitComparisonSign([NotNull] MoistParser.ComparisonSignContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.basicTypeValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBasicTypeValue([NotNull] MoistParser.BasicTypeValueContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.basicTypeValue"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBasicTypeValue([NotNull] MoistParser.BasicTypeValueContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionCall([NotNull] MoistParser.FunctionCallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.functionCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionCall([NotNull] MoistParser.FunctionCallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.functionDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionDeclaration([NotNull] MoistParser.FunctionDeclarationContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.functionDeclaration"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionDeclaration([NotNull] MoistParser.FunctionDeclarationContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.functionParameters"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunctionParameters([NotNull] MoistParser.FunctionParametersContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.functionParameters"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunctionParameters([NotNull] MoistParser.FunctionParametersContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.ifStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIfStatement([NotNull] MoistParser.IfStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.ifStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIfStatement([NotNull] MoistParser.IfStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.elseStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterElseStatement([NotNull] MoistParser.ElseStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.elseStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitElseStatement([NotNull] MoistParser.ElseStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.@return"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReturn([NotNull] MoistParser.ReturnContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.@return"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReturn([NotNull] MoistParser.ReturnContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.whileStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterWhileStatement([NotNull] MoistParser.WhileStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.whileStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitWhileStatement([NotNull] MoistParser.WhileStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.forStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterForStatement([NotNull] MoistParser.ForStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.forStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitForStatement([NotNull] MoistParser.ForStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.forEachStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterForEachStatement([NotNull] MoistParser.ForEachStatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.forEachStatement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitForEachStatement([NotNull] MoistParser.ForEachStatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.forEachVariable"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterForEachVariable([NotNull] MoistParser.ForEachVariableContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.forEachVariable"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitForEachVariable([NotNull] MoistParser.ForEachVariableContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.forEachCollection"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterForEachCollection([NotNull] MoistParser.ForEachCollectionContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.forEachCollection"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitForEachCollection([NotNull] MoistParser.ForEachCollectionContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.arrayIndexing"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArrayIndexing([NotNull] MoistParser.ArrayIndexingContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.arrayIndexing"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArrayIndexing([NotNull] MoistParser.ArrayIndexingContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.arrayOrVariable"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArrayOrVariable([NotNull] MoistParser.ArrayOrVariableContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.arrayOrVariable"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArrayOrVariable([NotNull] MoistParser.ArrayOrVariableContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.index"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIndex([NotNull] MoistParser.IndexContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.index"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIndex([NotNull] MoistParser.IndexContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="MoistParser.array"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArray([NotNull] MoistParser.ArrayContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="MoistParser.array"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArray([NotNull] MoistParser.ArrayContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
