using System.Globalization;
using System.Reflection;
using Antlr4.Runtime;
using Wuzh.Enums;
using Wuzh.ErrorListeners;
using Wuzh.Exceptions;
using Wuzh.Models;
using Wuzh.StandardLibrary;

namespace Wuzh;

public class WuzhVisitor : WuzhBaseVisitor<object>
{
    private static readonly object End = new();
        
    private readonly List<Variable> _variables = new();
    private readonly List<Function> _functions = new();
    
    private int _functionDepth;
    private int _scopeDepth;
    private readonly string _mainFile;
    private readonly string _input;
        
    private readonly ExceptionsFactory _exceptionsFactory;
    private Function? _currentFunction;
    private object _functionReturnValue = End;
    private BasicType _functionReturnType = BasicType.Unknown;

    public WuzhVisitor(string input, ExceptionsFactory exceptionsFactory)
    {
        _input = input;
        _exceptionsFactory = exceptionsFactory;
        _mainFile = exceptionsFactory.FileName;
    }

    public override object VisitImportStatement(WuzhParser.ImportStatementContext context)
    {
        var importFilePath = context.String().GetText().Replace("\"", "").Trim();
        if (!File.Exists(importFilePath))
        {
            throw _exceptionsFactory.ImportFileNotFound(importFilePath, 
                context.Start.Line, 
                context.Start.Column);
        }
        
        var fileText = File.ReadAllText(importFilePath);
        
        _exceptionsFactory.FileName = importFilePath;
        _exceptionsFactory.Input = fileText;
    
        var inputStream = new AntlrInputStream(fileText);
        var lexer = new WuzhLexer(inputStream);
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new LexerErrorListener(_exceptionsFactory));
    
        var commonTokenStream = new CommonTokenStream(lexer);
    
        var parser = new WuzhParser(commonTokenStream);
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ParserErrorListener(_exceptionsFactory));
    
        var importProgram = parser.program();
    
        Visit(importProgram);
        _variables.Clear();
        
        _exceptionsFactory.FileName = _mainFile;
        _exceptionsFactory.Input = _input;
        
        return End;
    }

    public override object VisitDeclaration(WuzhParser.DeclarationContext context)
    {
        var isConstant = context.GetChild(0).GetText() == "const";
        var variableName = context.Identificator().GetText();
        
        var existingVariable = GetVariable(variableName);
        if(existingVariable is not null)
        {
            var line = context.Start.Line;
            var column = context.Start.Column;
                
            throw _exceptionsFactory.VariableAlreadyDeclared(variableName, line, column);
        }
            
        var value = VisitExpression(context.expression());

        var variableType = GetBasicType(value);

        var typeHint = context.Type();
        if (typeHint is not null)
        {
            var hintedType = GetBasicTypeByName(typeHint.GetText());

            if (hintedType == BasicType.String)
            {
                value = value.ToWuzhString();
                variableType = BasicType.String;
            }
            
            if (hintedType == BasicType.Double && variableType == BasicType.Int)
            {
                value = (decimal)(int)value;
                variableType = BasicType.Double;
            }
            else if (hintedType != variableType && hintedType != BasicType.Any)
            {
                throw _exceptionsFactory.ValueOfTypeCanNotBeAssigned(GetBasicTypeByName(typeHint.GetText()), 
                    variableType, 
                    context.expression().Start.Line, 
                    context.expression().Start.Column);
            }
        }
        
        var variable = new Variable(variableName, value, variableType, isConstant, _functionDepth, _scopeDepth);

        _variables.Add(variable);

        return End;
    }

    public override object VisitAssignment(WuzhParser.AssignmentContext context)
    {
        var variableName = context.Identificator().GetText();
        var value = Visit(context.expression());

        var variable = GetVariable(variableName);
        if (variable is not null)
        {
            if (variable.IsConstant)
            {
                throw _exceptionsFactory.CanNotAssignToConstant(variableName, 
                    context.expression().Start.Line, 
                    context.expression().Start.Column);
            }
                
            if (variable.BasicType != GetBasicType(value))
            {
                throw _exceptionsFactory.ValueOfTypeCanNotBeAssigned(variable.BasicType, 
                    GetBasicType(value), 
                    context.expression().Start.Line, 
                    context.expression().Start.Column);
            }
                
            variable.Value = value;
        }
        else
        {
            throw _exceptionsFactory.VariableNotDeclared(variableName, context.Start.Line, context.Start.Column);
        }

        return End;
    }
        
    public override object VisitIndexAssignment(WuzhParser.IndexAssignmentContext context)
    {
        var variableName = context.Identificator().GetText();
        var index = Visit(context.index());
        var value = Visit(context.expression());

        var variable = GetVariable(variableName);
        if (variable is not null)
        {
            if (variable.IsConstant)
            {
                throw _exceptionsFactory.CanNotAssignToConstant(variableName, 
                    context.expression().Start.Line, 
                    context.expression().Start.Column);
            }

            if (variable.BasicType == BasicType.Array)
            {
                var arrVariable = (List<object>)variable.Value;

                if (arrVariable.Count <= (int)index)
                {
                    throw _exceptionsFactory.IndexOutOfRangeException(context.index().Start.Line, 
                        context.index().Start.Column);
                }
                
                arrVariable[(int)index] = value;
                    
                variable.Value = arrVariable;
            }
            else if (variable.BasicType == BasicType.String)
            {
                var arrVariable = (string)variable.Value;
                
                if (arrVariable.Length <= (int)index)
                {
                    throw _exceptionsFactory.IndexOutOfRangeException(context.index().Start.Line, 
                        context.index().Start.Column);
                }
                
                arrVariable = arrVariable.Remove((int)index, 1);
                arrVariable = arrVariable.Insert((int)index, value.ToString()!);
                    
                variable.Value = arrVariable;
            }
            else if (variable.BasicType == BasicType.Dictionary)
            {
                var arrVariable = (Dictionary<string, object>)variable.Value;
                var strIndex = ((string)index);
                
                arrVariable[strIndex] = value;
                    
                variable.Value = arrVariable;
            }
                
        }
        else
        {
            throw _exceptionsFactory.VariableNotDeclared(variableName, context.Start.Line, context.Start.Column);
        }

        return End;
    }

    public override object VisitExpression(WuzhParser.ExpressionContext context)
    {
        if (context.Plus() != null || context.Minus() != null)
        {
            var left = VisitMultiplyExpression(context.multiplyExpression(0));
                
            if (left is bool leftResult && context.ExclamationMark() is not null)
            {
                return !leftResult;
            }
            if (left is not bool && context.ExclamationMark() is not null)
            {
                throw _exceptionsFactory.ExpressionIsNotBoolean(context.multiplyExpression(0).GetText(), 
                    context.multiplyExpression(0).Start.Line, 
                    context.multiplyExpression(0).Start.Column);
            }
                
            for (var i = 1; i < context.multiplyExpression().Length; i++)
            {
                var op = context.Plus(i - 1) != null ? "+" : "-";
                var right = VisitMultiplyExpression(context.multiplyExpression(i));

                left = PerformOperation(left, right, op, context.Start.Line, context.Start.Column);
            }

            if (context.comparisonRightSide() is { } c)
            {
                var right = VisitExpression(c.expression());
                var sign = c.comparisonSign().GetText();
                return VisitComparison(context, left, right, sign);
            }
                
            return left;
        }

        var result = Visit(context.multiplyExpression(0));
            
        if (result is bool boolResult && context.ExclamationMark() is not null)
        {
            if (context.comparisonRightSide() is { } c)
            {
                var right = VisitExpression(c.expression());
                var sign = c.comparisonSign().GetText();
                return VisitComparison(context, result, right, sign);
            }
                
            return !boolResult;
        }
            
        if (result is not bool && context.ExclamationMark() is not null)
        {
            throw _exceptionsFactory.ExpressionIsNotBoolean(context.multiplyExpression(0).GetText(), 
                context.multiplyExpression(0).Start.Line, 
                context.multiplyExpression(0).Start.Column);
        }
            
            
        if (context.comparisonRightSide() is { } e)
        {
            var right = VisitExpression(e.expression());
            var sign = e.comparisonSign().GetText();
            return VisitComparison(context, result, right, sign);
        }

        return result;
    }

    public override object VisitMultiplyExpression(WuzhParser.MultiplyExpressionContext context)
    {
        if (context.Multiply() != null || context.Divide() != null)
        {
            var left = VisitValue(context.value(0));
            for (var i = 1; i < context.value().Length; i++)
            {
                var op = "";
                if (context.Multiply(i - 1) is not null)
                {
                    op = "*";
                }
                else if (context.Divide(i - 1) is not null)
                {
                    op = "/";
                }
                else if (context.FloorDivide(i - 1) is not null)
                {
                    op = "//";
                }
                else if (context.Remainder(i - 1) is not null)
                {
                    op = "%";
                }

                var right = Visit(context.value(i));

                left = PerformOperation(left, right, op, context.Start.Line, context.Start.Column);
            }
                
            return left;
        }

        return VisitValue(context.value(0));
    }

    private object VisitComparison(WuzhParser.ExpressionContext context, object left, object right, string sign)
    {
        var leftType = GetBasicType(left);
        var rightType = GetBasicType(right);
            
        if (leftType != rightType)
        {
            throw _exceptionsFactory.DifferentTypesComparison(leftType.ToString(), rightType.ToString(), 
                context.Start.Line, 
                context.Start.Column);
        }
            
        // int comparison
        if (leftType == BasicType.Int)
        {
            return sign switch
            {
                ">" => (int)left > (int)right,
                ">=" => (int)left >= (int)right,
                "<" => (int)left < (int)right,
                "<=" => (int)left <= (int)right,
                "==" => left.Equals(right),
                "!=" => !left.Equals(right),
                _ => throw _exceptionsFactory.UnknownOperator(sign, 
                    context.comparisonRightSide().comparisonSign().Start.Line, 
                    context.comparisonRightSide().comparisonSign().Start.Column)
            };
        }

        if (leftType == BasicType.Double)
        {
            return sign switch
            {
                ">" => (decimal)left > (decimal)right,
                ">=" => (decimal)left >= (decimal)right,
                "<" => (decimal)left < (decimal)right,
                "<=" => (decimal)left <= (decimal)right,
                "==" => left.Equals(right),
                "!=" => !left.Equals(right),
                _ => throw _exceptionsFactory.UnknownOperator(sign, 
                    context.comparisonRightSide().comparisonSign().Start.Line, 
                    context.comparisonRightSide().comparisonSign().Start.Column)
            };
        }
            
        if (leftType == BasicType.String)
        {
            return sign switch
            {
                "==" => left.Equals(right),
                "!=" => !left.Equals(right),
                _ => throw _exceptionsFactory.UnknownOperator(sign, 
                    context.comparisonRightSide().comparisonSign().Start.Line, 
                    context.comparisonRightSide().comparisonSign().Start.Column)
            };
        }
            
        if (leftType == BasicType.Bool)
        {
            return sign switch
            {
                "==" => left.Equals(right),
                "!=" => !left.Equals(right),
                "&&" => (bool)left && (bool)right,
                "||" => (bool)left || (bool)right,
                _ => throw _exceptionsFactory.UnknownOperator(sign, 
                    context.comparisonRightSide().comparisonSign().Start.Line, 
                    context.comparisonRightSide().comparisonSign().Start.Column)
            };
        }

        return End;
    }
        
    public override object VisitValue(WuzhParser.ValueContext context)
    {
        if (context.basicTypeValue() is not null)
        {
            if(context.Minus() is not null 
               && context.basicTypeValue().Integer() is null 
               && context.basicTypeValue().Double() is null)
            {
                throw _exceptionsFactory.OperatorNotSupportedForNotIntOrDoubleValues("-", 
                    context.Start.Line, 
                    context.Start.Column);
            }
            
            if (context.basicTypeValue().Unit() != null)
            {
                return Unit.Value;
            }
                
            if (context.basicTypeValue().Integer() != null)
            {
                var minus = context.Minus() != null ? -1 : 1;
                return minus * 
                       int.Parse(context.basicTypeValue().Integer().GetText());
            }
                
            if (context.basicTypeValue().Double() != null)
            {
                var minus = context.Minus() != null ? -1 : 1;
                return minus * 
                       decimal.Parse(context.basicTypeValue().Double().GetText(), 
                           CultureInfo.InvariantCulture);
            }

            if (context.basicTypeValue().String() != null)
            {
                return context.basicTypeValue().String()
                    .GetText()[1..^1] // remove quotes
                    .Replace("\\\"","\""); // unescape quotes
            }

            if (context.basicTypeValue().Boolean() != null)
            {
                return context.basicTypeValue().Boolean().GetText() == "true";
            }
                
            if (context.basicTypeValue().array() != null)
            {
                var array = new List<object>();
                foreach (var value in context.basicTypeValue().array().expression())
                {
                    array.Add(VisitExpression(value));
                }

                return array;
            }

            if (context.basicTypeValue().range() != null)
            {
                var firstValue = Visit(context.basicTypeValue().range().expression(0));
                var secondValue = Visit(context.basicTypeValue().range().expression(1));

                if (firstValue is not int firstIntegerValue)
                {
                    throw _exceptionsFactory.RangeItemMustBeInteger(
                        context.basicTypeValue().range().expression(0).Start.Line,
                        context.basicTypeValue().range().expression(0).Start.Column);
                }

                if (secondValue is not int secondIntegerValue)
                {
                    throw _exceptionsFactory.RangeItemMustBeInteger(
                        context.basicTypeValue().range().expression(0).Start.Line,
                        context.basicTypeValue().range().expression(0).Start.Column);
                }

                if (firstIntegerValue > secondIntegerValue)
                {
                    throw _exceptionsFactory.RangeStartMustBeLessThanEnd(
                        context.basicTypeValue().range().expression(0).Start.Line,
                        context.basicTypeValue().range().expression(0).Start.Column);
                }

                var array = Enumerable.Range(firstIntegerValue, secondIntegerValue - firstIntegerValue + 1)
                    .Select(x => (object)x)
                    .ToList();

                return array;
            }
            
            if (context.basicTypeValue().dictionary() != null)
            {
                var array = new Dictionary<string, object>();
                foreach (var dictionaryElement in context.basicTypeValue().dictionary().dictionaryEntry())
                {
                    var key = dictionaryElement.String().GetText()[1..^1];
                    var value = VisitExpression(dictionaryElement.expression());
                    array.Add(key, value);
                }

                return array;
            }
        }

        if (context.arrayIndexing() != null)
        {
            if(context.Minus() is not null)
            {
                throw _exceptionsFactory.IndexOutOfRangeException(
                    context.basicTypeValue().Start.Line, 
                    context.basicTypeValue().Start.Column);
            }
            
            return VisitArrayIndexing(context.arrayIndexing());
        }

        if (context.functionCall() != null)
        {
            var minus = context.Minus() != null ? -1 : 1;
            var ret = VisitFunctionCall(context.functionCall());

            if (minus == -1)
            {
                if (ret is not int && ret is not decimal)
                {
                    throw _exceptionsFactory.OperatorNotSupportedForNotIntOrDoubleValues("-", 
                        context.functionCall().Start.Line, 
                        context.functionCall().Start.Column);
                }

                return minus * (int)ret;
            }
            
            return ret;
        }

        if (context.expression() != null)
        {
            var minus = context.Minus() != null ? -1 : 1;
            var ret = Visit(context.expression());

            if (minus == -1)
            {
                if (ret is not int && ret is not decimal)
                {
                    throw _exceptionsFactory.OperatorNotSupportedForNotIntOrDoubleValues("-", 
                        context.functionCall().Start.Line, 
                        context.functionCall().Start.Column);
                }

                return minus * (int)ret;
            }
            
            return ret;
        }
            
        if (context.Identificator() != null)
        {
            var variableName = context.Identificator().GetText();
                
            var variable = GetVariable(variableName);
            if (variable is not null)
            {
                var minus = context.Minus() != null ? -1 : 1;
                var ret = variable.Value;

                if (minus == -1)
                {
                    if (ret is not int && ret is not decimal)
                    {
                        throw _exceptionsFactory.OperatorNotSupportedForNotIntOrDoubleValues("-", 
                            context.functionCall().Start.Line, 
                            context.functionCall().Start.Column);
                    }

                    return minus * (int)ret;
                }
                
                return ret;
            }

            throw _exceptionsFactory.VariableNotDeclared(variableName, context.Start.Line, context.Start.Column);
        }

        return End;
    }

    public override object VisitIfStatement(WuzhParser.IfStatementContext context)
    {
        _scopeDepth++;
        
        var condition = Visit(context.expression());

        if (condition is not bool boolCondition)
        {
            throw _exceptionsFactory.ExpressionIsNotBoolean(context.expression().GetText(), 
                context.expression().Start.Line, 
                context.expression().Start.Column);
        }
            
        if (boolCondition)
        {
            foreach (var statement in context.statement())
            {
                VisitStatement(statement);
            }
        }
        else
        {
            if (context.elseStatement() != null)
            {
                foreach (var statement in context.elseStatement().statement())
                {
                    VisitStatement(statement);
                }
            }
        }

        ResetScope();

        return End;
    }

    public override object VisitWhileStatement(WuzhParser.WhileStatementContext context)
    {
        _scopeDepth++;
        
        var condition = Visit(context.expression());

        if (condition is not bool boolCondition)
        {
            throw _exceptionsFactory.ExpressionIsNotBoolean(context.expression().GetText(), 
                context.expression().Start.Line, 
                context.expression().Start.Column);
        }

        while (boolCondition)
        {
            foreach (var statement in context.statement())
            {
                VisitStatement(statement);
            }
                
            boolCondition = (bool)Visit(context.expression());
        }
        
        ResetScope();

        return End;
    }

    public override object VisitForStatement(WuzhParser.ForStatementContext context)
    {
        _scopeDepth++;
        
        var declaration = context.declaration();
        if (declaration is null)
        {
            throw _exceptionsFactory.ForLoopVariableNotDeclared(context.GetText(), 
                context.Start.Line, 
                context.Start.Column);
        }
        VisitDeclaration(declaration);
        
        var expression = context.expression();
            
        if (expression is null)
        {
            throw _exceptionsFactory.ForLoopStepNotDeclared(context.GetText(), 
                context.Start.Line, 
                context.Start.Column);
        }

        var condition = Visit(expression);
            
        if (condition is null)
        {
            throw _exceptionsFactory.ForLoopConditionNotDeclared(context.GetText(), 
                context.Start.Line, 
                context.Start.Column);
        }

        if (condition is not bool boolCondition)
        {
            throw _exceptionsFactory.ExpressionIsNotBoolean(expression.GetText(), 
                expression.Start.Line, 
                expression.Start.Column);
        }

        while (boolCondition)
        {
            foreach (var statement in context.statement())
            {
                VisitStatement(statement);
            }

            var step = context.assignment();
                
            if (step is null)
            {
                throw _exceptionsFactory.ForLoopStepNotDeclared(context.expression().GetText(), 
                    context.Start.Line, 
                    context.Start.Column);
            }
                
            VisitAssignment(step);
            boolCondition = (bool)Visit(expression);
        }
        
        ResetScope();

        return End;
    }

    public override object VisitForEachStatement(WuzhParser.ForEachStatementContext context)
    {
        var iterationVariableName = context.forEachVariable().GetText();
        
        var variable = GetVariable(iterationVariableName);
        if (variable is null)
        {
            _variables.Add(new Variable(iterationVariableName, End, 
                BasicType.Unknown, false, _functionDepth, _scopeDepth));

            variable = GetVariable(iterationVariableName)!;
        }

        var collection = context.forEachCollection();
        var collectionValue = VisitExpression(collection.expression());
        var collectionType = GetBasicType(collectionValue);

        EnsureCollectionTypeIsSupported(collectionType, collection.expression().Start.Line, collection.expression().Start.Column);

        var statements = context.statement();
        var isStringCollection = collectionType == BasicType.String;

        foreach (var element in GetCollectionElements(collectionValue, isStringCollection))
        {
            _scopeDepth++;
            variable.Value = element;
            variable.BasicType = isStringCollection ? BasicType.String : GetBasicType(element);

            foreach (var statement in statements)
            {
                VisitStatement(statement);
            }

            ResetScope();
        }

        return End;
    }

    private IEnumerable<object> GetCollectionElements(object collection, bool isStringCollection)
    {
        if (isStringCollection)
        {
            foreach (var str in (string)collection)
            {
                yield return str.ToString();
            }
        }
        else
        {
            foreach (var elem in (List<object>)collection)
            {
                yield return elem;
            }
        }
    }

    private void EnsureCollectionTypeIsSupported(BasicType collectionType, int line, int column)
    {
        if (collectionType != BasicType.Array && collectionType != BasicType.String)
        {
            throw _exceptionsFactory.UnsupportedTypeAsCollection(collectionType.ToString(), line, column);
        }
    }

    public override object VisitFunctionCall(WuzhParser.FunctionCallContext context)
    {
        var functionName = context.Identificator().GetText();
        var argumentsValues = new List<object>();
            
        if (context.expression().Length > 0)
        {
            argumentsValues.AddRange(
                context.expression().Select(Visit)
            );
        }

        var userFunction = _functions
            .FirstOrDefault(x => x.Name == functionName 
                                 && x.Arguments.Count == argumentsValues.Count
                                 && FunctionsParametersOverlap(x.ArgumentsTypes, 
                                     argumentsValues.Select(GetBasicType).ToList()));

        if (userFunction is null)
        {
            userFunction = _functions.FirstOrDefault(x => x.Name == functionName 
                                                          && x.Arguments.Count == argumentsValues.Count
                                                          && x.ArgumentsTypes.All(y => y == BasicType.Any));
        }
        
        _currentFunction = userFunction;
        
        if (userFunction is not null)
        {
            _functionDepth++;
                
            for (var i = 0; i < userFunction.Arguments.Count; i++)
            {
                var argument = new Variable(userFunction.Arguments[i], argumentsValues[i],
                    GetBasicType(argumentsValues[i]), false, _functionDepth, _scopeDepth);

                if (argument.BasicType != userFunction.ArgumentsTypes[i] && argument.BasicType == BasicType.Any)
                {
                    throw _exceptionsFactory.ValueOfTypeCanNotBeAssigned(userFunction.ArgumentsTypes[i], 
                        argument.BasicType, 
                        context.expression(i).Start.Line, 
                        context.expression(i).Start.Column);
                }

                _variables.Add(argument);
            }
            
            foreach (var statement in userFunction.Statements)
            {
                var ret = Visit(statement);

                if (ret != Unit.Value && _functionReturnType != BasicType.Unknown)
                {
                    var retValue = _functionReturnValue;
                    
                    ResetFunctionScope();
                        
                    return retValue;
                }
            }

            ResetFunctionScope();

            return Unit.Value;
        }

        var function = InvokeStandardLibraryFunction(functionName, 
            argumentsValues.ToArray(), 
            context.Start.Line, 
            context.Start.Column)!;

        return function;
    }

    public override object VisitFunctionDeclaration(WuzhParser.FunctionDeclarationContext context)
    {
        var functionName = context.Identificator().GetText();
        var parameters = 
            context.functionParameters()?.parameter().ToList()
            ?? new List<WuzhParser.ParameterContext>();

        var parametersNames = parameters.Select(x => x.Identificator().GetText()).ToList();
        var parametersTypes = parameters.Select(x => GetBasicTypeByName(x.Type()?.GetText() ?? "")).ToList();
        
        var i = 0;
        foreach (var parameter in parametersNames)
        {
            var variable = GetVariable(parameter);
            if (variable is not null)
            {
                throw _exceptionsFactory.GlobalVariableWithSameNameAlreadyDeclared(parameter, 
                    context.Start.Line, 
                    context.Start.Column + "func ".Length + functionName.Length + 1 + i);
            }

            i += parameter.Length + 1;
            i++;
        }

        var returnType = BasicType.Any;
        if (context.Type() is not null)
        {
            returnType = GetBasicTypeByName(context.Type().GetText());
        }

        var function = new Function(functionName, 
            _exceptionsFactory.FileName, 
            parametersNames, 
            parametersTypes,
            context.statement().ToList(),
            returnType);
        if (_functions.Any(x => x.Name == functionName && x.Arguments.Count == parametersNames.Count && 
                                FunctionsParametersOverlap(x.ArgumentsTypes, function.ArgumentsTypes)))
        {
            throw _exceptionsFactory.FunctionAlreadyDeclared(functionName, parametersNames.Count,
                context.Start.Line, context.Start.Column);
        }

        _functions.Add(function);
                
        return End;
    }

    private static bool FunctionsParametersOverlap(IReadOnlyList<BasicType> first, IReadOnlyList<BasicType> second)
    {
        for (var i = 0; i < first.Count; i++)
        {
            if (first[i] != BasicType.Any && second[i] != BasicType.Any && first[i] != second[i])
            {
                return false;
            }
        }

        return true;
    }

    public override object VisitArrayIndexing(WuzhParser.ArrayIndexingContext context)
    {
        object indexValue = default!;
            
        // Index
        var index = context.index();
        if (index.Identificator() != null)
        {
            var variableName = index.Identificator().GetText();
           
            var variable = GetVariable(variableName);
            if (variable is null)
            {
                throw _exceptionsFactory.VariableNotDeclared(variableName, 
                    index.Start.Line, 
                    index.Start.Column);
            }
                
            indexValue = variable.Value;
        }
        else if (index.expression() != null)
        {
            var value = VisitExpression(index.expression());
                
            indexValue = value;
        }
        
        var valueType = GetBasicType(indexValue);

        if (indexValue is int integerIndex && integerIndex < 0)
        {
            throw _exceptionsFactory.IndexOutOfRangeException(index.Start.Line, index.Start.Column);
        }
            
        // Array 
        if (context.arrayOrVariable().Identificator() != null)
        {
            var variableName = context.arrayOrVariable().Identificator().GetText();
            
            var variable = GetVariable(variableName);
            if (variable is null)
            {
                throw _exceptionsFactory.VariableNotDeclared(variableName, 
                    index.Start.Line, 
                    index.Start.Column);
            }
            
            if (variable.BasicType == BasicType.String)
            {
                if (valueType != BasicType.Int)
                {
                    throw _exceptionsFactory.ArrayIndexerMustBeInteger(valueType, 
                        index.Start.Line, 
                        index.Start.Column);
                }
            
                if (((string)variable.Value).Length <= (int)indexValue)
                {
                    throw _exceptionsFactory.IndexOutOfRangeException(index.Start.Line, index.Start.Column);
                }
                
                return ((string)variable.Value)[(int)indexValue].ToString();
            }

            if (variable.BasicType == BasicType.Array)
            {
                if (valueType != BasicType.Int)
                {
                    throw _exceptionsFactory.ArrayIndexerMustBeInteger(valueType, 
                        index.Start.Line, 
                        index.Start.Column);
                }
                
                if (((List<object>)variable.Value).Count <= (int)indexValue)
                {
                    throw _exceptionsFactory.IndexOutOfRangeException(index.Start.Line, index.Start.Column);
                }
                    
                return ((List<object>)variable.Value)[(int)indexValue];
            }
            
            if (variable.BasicType == BasicType.Dictionary)
            {
                if (valueType != BasicType.String)
                {
                    throw _exceptionsFactory.DictionaryIndexerMustBeString(valueType, 
                        index.Start.Line, 
                        index.Start.Column);
                }
                
                var dict = (Dictionary<string, object>)variable.Value;
                var key = indexValue.ToString() ?? "";

                if (!dict.ContainsKey(key))
                {
                    throw _exceptionsFactory.DictionaryDoesNotContainKey(key, 
                        index.Start.Line, 
                        index.Start.Column);
                }
                
                return dict[key];
            }
        }
        if (context.arrayOrVariable().array() != null)
        {
            var array = new List<object>();
            foreach (var value in context.arrayOrVariable().array().expression())
            {
                array.Add(VisitExpression(value));
            }

            if (array.Count <= (int)indexValue)
            {
                throw _exceptionsFactory.IndexOutOfRangeException(index.Start.Line, index.Start.Column);
            }

            return array[(int)indexValue];
        }

        return End;
    }

    public override object VisitReturn(WuzhParser.ReturnContext context)
    {
        if (_functionDepth == 0)
        {
            throw _exceptionsFactory.ReturnOutsideFunction(context.Start.Line, context.Start.Column);
        }

        var value = VisitExpression(context.expression());

        _functionReturnValue = value;
        _functionReturnType = GetBasicType(value);

        if (_currentFunction is not null && _currentFunction.ReturnType != _functionReturnType && _currentFunction.ReturnType != BasicType.Any)
        {
            throw _exceptionsFactory.ReturnTypeDoesNotMatchFunctionReturnType(_currentFunction.Name, _currentFunction.ReturnType, 
                _functionReturnType, 
                context.Start.Line, 
                context.Start.Column);
        }

        return value;
    }

    #region Helpers
        
    private void ResetFunctionScope()
    {
        _functionReturnValue = End;
        _functionReturnType = BasicType.Unknown;
            
        foreach (var variable in 
                 _variables
                     .Where(x => x.FunctionDepth == _functionDepth).ToList())
        {
            _variables.Remove(variable);
        }

        if (_functionDepth != 0)
        {
            _functionDepth--;
        }
    }
    
    private void ResetScope()
    {
        foreach (var variable in 
                 _variables
                     .Where(x => x.ScopeDepth == _scopeDepth).ToList())
        {
            _variables.Remove(variable);
        }
        
        _scopeDepth--;
    }

    private Variable? GetVariable(string name)
    {
        var inCurrentScope = _variables
            .FirstOrDefault(x => x.Name == name && x.FunctionDepth == _functionDepth);

        if (inCurrentScope is null)
        {
            return _variables
                .FirstOrDefault(x => x.Name == name && x.FunctionDepth == 0);
        }
        else
        {
            return inCurrentScope;
        }
    }
        
    public static BasicType GetBasicType(object value)
    {
        return value switch
        {
            Unit => BasicType.Unit,
            int => BasicType.Int,
            decimal => BasicType.Double,
            string => BasicType.String,
            bool => BasicType.Bool,
            List<object> => BasicType.Array,
            Dictionary<string, object> => BasicType.Dictionary,
            _ => BasicType.Unknown
        };
    }

    private static BasicType GetBasicTypeByType(Type type)
    {
        return type switch
        {
            not null when type == typeof(Unit) => BasicType.Unit,
            not null when type == typeof(int) => BasicType.Int,
            not null when type == typeof(decimal) => BasicType.Double,
            not null when type == typeof(string) => BasicType.String,
            not null when type == typeof(bool) => BasicType.Bool,
            not null when type == typeof(List<object>) => BasicType.Array,
            not null when type == typeof(Dictionary<string, object>) => BasicType.Dictionary,
            _ => BasicType.Unknown
        };
    }
    
    private static BasicType GetBasicTypeByName(string typeName)
    {
        return typeName switch
        {
            "Unit" => BasicType.Unit,
            "Int" => BasicType.Int,
            "Double" => BasicType.Double,
            "String" => BasicType.String,
            "Bool" => BasicType.Bool,
            "Array" => BasicType.Array,
            "Dict" or "Dictionary" => BasicType.Dictionary,
            "Any" or "" => BasicType.Any,
            _ => BasicType.Unknown
        };
    }
        
    private object? InvokeStandardLibraryFunction(string functionName, object[] arguments, int line, int column)
    {
        var argumentsTypes = arguments.Select(GetBasicType).ToList();

        var allMethods = typeof(ConsoleFunctions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static)
            .ToList();
        
        allMethods.AddRange(typeof(ArrayFunctions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static));
        
        allMethods.AddRange(typeof(DictionaryFunctions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static));
        
        allMethods.AddRange(typeof(NumberFunctions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static));
        
        allMethods.AddRange(typeof(MainFunctions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static));
        
        allMethods.AddRange(typeof(StringFunctions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static));
        
        allMethods.AddRange(typeof(TypeConvertFunctions)
            .GetMethods(BindingFlags.Public | BindingFlags.Static));
        
        var methods = allMethods
            .Where(method => method.Name == functionName 
                             && (method.GetParameters().Length == arguments.Length 
                                 || (method.GetParameters().Length == 1 
                                     && method.GetParameters().First().ParameterType == typeof(object[]))))
            .ToList();

        MethodInfo? method;

        if (methods.Count == 1)
        {
            method = methods[0];
        }
        else
        {
            method = methods
                .FirstOrDefault(
                    x => x.GetParameters().Select(y => GetBasicTypeByType(y.ParameterType))
                        .SequenceEqual(argumentsTypes)
                );
        }
            
        if (method == null)
        {
            throw _exceptionsFactory.FunctionNotDeclaredWithArgumentTypes(functionName, argumentsTypes, line,
                column);
        }
        
        var methodParameters = method.GetParameters();
        if (methodParameters.Length == 1 && methodParameters.First().ParameterType == typeof(object[]))
        {
            var paramsArr = new object[] { arguments };
            arguments = paramsArr;
        }

        try
        {
            return method.Invoke(null, arguments);
        }
        catch
        {
            throw _exceptionsFactory.FunctionNotDeclaredWithArgumentTypes(functionName, argumentsTypes, line, column);
        }
    }

    private object PerformOperation(object left, object right, string op, int line, int column)
    {
        try
        {
            if (left is int leftInt && right is int rightInt) {
                return op switch
                {
                    "+" => leftInt + rightInt,
                    "-" => leftInt - rightInt,
                    "*" => leftInt * rightInt,
                    "/" => leftInt / rightInt,
                    "%" => leftInt % rightInt,
                    "//" => leftInt / rightInt,
                    _ => throw _exceptionsFactory.UnknownOperator(op, line, column)
                };
            }
                
            if (left is decimal leftD && right is decimal rightD)
            {
                return op switch
                {
                    "+" => leftD + rightD,
                    "-" => leftD - rightD,
                    "*" => leftD * rightD,
                    "/" => leftD / rightD,
                    "%" => leftD % rightD,
                    "//" => (int)(leftD / rightD),
                    _ => throw _exceptionsFactory.UnknownOperator(op, line, column)
                };
            }
                
            if (left is decimal dec && right is int integer)
            {
                return op switch
                {
                    "+" => dec + integer,
                    "-" => dec - integer,
                    "*" => dec * integer,
                    "/" => dec / integer,
                    "%" => dec % integer,
                    "//" => (int)(dec / integer),
                    _ => throw _exceptionsFactory.UnknownOperator(op, line, column)
                };
            }
                
            if (left is int integer2 && right is decimal dec2)
            {
                return op switch
                {
                    "+" => integer2 + dec2,
                    "-" => integer2 - dec2,
                    "*" => integer2 * dec2,
                    "/" => integer2 / dec2,
                    "%" => integer2 % dec2,
                    "//" => (int)(integer2 / dec2),
                    _ => throw _exceptionsFactory.UnknownOperator(op, line, column)
                };
            }
                
            if (left is string leftStr && right is string rightStr)
            {
                return op switch
                {
                    "+" => leftStr + rightStr,
                    _ => throw _exceptionsFactory.UnknownOperator(op, line, column)
                };
            }
                
            if (left is string str)
            {
                if (right is int @int && op == "*")
                {
                    return string.Concat(Enumerable.Repeat(str, @int));
                }
                
                return op switch
                {
                    "+" => str + right.ToWuzhString(),
                    _ => throw _exceptionsFactory.UnknownOperator(op, line, column)
                };
            }
                
            if (right is string str1)
            {
                if (left is int @int && op == "*")
                {
                    return string.Concat(Enumerable.Repeat(str1, @int));
                }
                
                return op switch
                {
                    "+" => left.ToWuzhString() + str1,
                    _ => throw _exceptionsFactory.UnknownOperator(op, line, column)
                };
            }
            
            if (left is List<object> list1 && right is List<object> list2)
            {
                return op switch
                {
                    "+" => list1.Concat(list2).ToList(),
                    _ => throw _exceptionsFactory.UnknownOperator(op, line, column)
                };
            }
        }
        catch(DivideByZeroException)
        {
            throw _exceptionsFactory.DivisionByZero(line, column);
        }
        catch(Exception)
        {
            throw _exceptionsFactory.OperatorNotSupportedForTypes(op, 
                GetBasicType(left), 
                GetBasicType(right), 
                line, 
                column);
        }

        throw _exceptionsFactory.OperatorNotSupportedForTypes(op, 
            GetBasicType(left), 
            GetBasicType(right), 
            line, 
            column);
    }

    #endregion
}