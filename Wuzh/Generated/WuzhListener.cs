//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Wuzh.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="WuzhParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public interface IWuzhListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] WuzhParser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] WuzhParser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.importStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterImportStatement([NotNull] WuzhParser.ImportStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.importStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitImportStatement([NotNull] WuzhParser.ImportStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] WuzhParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] WuzhParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.semicolonTerminatedStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSemicolonTerminatedStatement([NotNull] WuzhParser.SemicolonTerminatedStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.semicolonTerminatedStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSemicolonTerminatedStatement([NotNull] WuzhParser.SemicolonTerminatedStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.braceTerminatedStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBraceTerminatedStatement([NotNull] WuzhParser.BraceTerminatedStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.braceTerminatedStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBraceTerminatedStatement([NotNull] WuzhParser.BraceTerminatedStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaration([NotNull] WuzhParser.DeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.declaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaration([NotNull] WuzhParser.DeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAssignment([NotNull] WuzhParser.AssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAssignment([NotNull] WuzhParser.AssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.indexAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndexAssignment([NotNull] WuzhParser.IndexAssignmentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.indexAssignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndexAssignment([NotNull] WuzhParser.IndexAssignmentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] WuzhParser.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] WuzhParser.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.multiplyExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultiplyExpression([NotNull] WuzhParser.MultiplyExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.multiplyExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultiplyExpression([NotNull] WuzhParser.MultiplyExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterValue([NotNull] WuzhParser.ValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitValue([NotNull] WuzhParser.ValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.comparisonRightSide"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparisonRightSide([NotNull] WuzhParser.ComparisonRightSideContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.comparisonRightSide"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparisonRightSide([NotNull] WuzhParser.ComparisonRightSideContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.comparisonSign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComparisonSign([NotNull] WuzhParser.ComparisonSignContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.comparisonSign"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComparisonSign([NotNull] WuzhParser.ComparisonSignContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.basicTypeValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBasicTypeValue([NotNull] WuzhParser.BasicTypeValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.basicTypeValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBasicTypeValue([NotNull] WuzhParser.BasicTypeValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionCall([NotNull] WuzhParser.FunctionCallContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionCall([NotNull] WuzhParser.FunctionCallContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.functionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionName([NotNull] WuzhParser.FunctionNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.functionName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionName([NotNull] WuzhParser.FunctionNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.functionDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionDeclaration([NotNull] WuzhParser.FunctionDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.functionDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionDeclaration([NotNull] WuzhParser.FunctionDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.functionParameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunctionParameters([NotNull] WuzhParser.FunctionParametersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.functionParameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunctionParameters([NotNull] WuzhParser.FunctionParametersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameter([NotNull] WuzhParser.ParameterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.parameter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameter([NotNull] WuzhParser.ParameterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfStatement([NotNull] WuzhParser.IfStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfStatement([NotNull] WuzhParser.IfStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElseStatement([NotNull] WuzhParser.ElseStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.elseStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElseStatement([NotNull] WuzhParser.ElseStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.return"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterReturn([NotNull] WuzhParser.ReturnContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.return"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitReturn([NotNull] WuzhParser.ReturnContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterWhileStatement([NotNull] WuzhParser.WhileStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitWhileStatement([NotNull] WuzhParser.WhileStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForStatement([NotNull] WuzhParser.ForStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForStatement([NotNull] WuzhParser.ForStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.forEachStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForEachStatement([NotNull] WuzhParser.ForEachStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.forEachStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForEachStatement([NotNull] WuzhParser.ForEachStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.forEachVariable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForEachVariable([NotNull] WuzhParser.ForEachVariableContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.forEachVariable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForEachVariable([NotNull] WuzhParser.ForEachVariableContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.forEachCollection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForEachCollection([NotNull] WuzhParser.ForEachCollectionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.forEachCollection"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForEachCollection([NotNull] WuzhParser.ForEachCollectionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.arrayIndexing"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayIndexing([NotNull] WuzhParser.ArrayIndexingContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.arrayIndexing"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayIndexing([NotNull] WuzhParser.ArrayIndexingContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.arrayOrVariable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayOrVariable([NotNull] WuzhParser.ArrayOrVariableContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.arrayOrVariable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayOrVariable([NotNull] WuzhParser.ArrayOrVariableContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.index"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndex([NotNull] WuzhParser.IndexContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.index"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndex([NotNull] WuzhParser.IndexContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArray([NotNull] WuzhParser.ArrayContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.array"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArray([NotNull] WuzhParser.ArrayContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.range"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRange([NotNull] WuzhParser.RangeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.range"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRange([NotNull] WuzhParser.RangeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.dictionary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDictionary([NotNull] WuzhParser.DictionaryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.dictionary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDictionary([NotNull] WuzhParser.DictionaryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="WuzhParser.dictionaryEntry"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDictionaryEntry([NotNull] WuzhParser.DictionaryEntryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="WuzhParser.dictionaryEntry"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDictionaryEntry([NotNull] WuzhParser.DictionaryEntryContext context);
}
