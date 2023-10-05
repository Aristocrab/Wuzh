using System.Globalization;
using System.Reflection;
using Moist.Enums;
using Moist.Exceptions;
using Moist.Models;
using Moist.StandardLibrary;

namespace Moist;

public class MoistVisitor : MoistBaseVisitor<object>
{
    private static readonly object End = new();
        
    private readonly List<Variable> _variables = new();
    private readonly List<Function> _functions = new();
    
    private readonly Stack<string> _visitedFunctions = new();
    private int _recursionDepth;
        
    private readonly InterpreterExceptionsFactory _interpreterExceptionsFactory;
    private object _functionReturnValue = End;
    private BasicType _functionReturnType = BasicType.Unknown;

    public MoistVisitor(string input)
    {
        _interpreterExceptionsFactory = new InterpreterExceptionsFactory(input);
        _visitedFunctions.Push("$global");
    }

    public override object VisitDeclaration(MoistParser.DeclarationContext context)
    {
        var isConstant = context.GetChild(0).GetText() == "const";
        var variableName = context.Identificator().GetText();
            
        if(_variables.Any(x => x.Name == variableName && x.Caller == GetCurrentFunctionName()))
        {
            var line = context.Start.Line;
            var column = context.Start.Column;
                
            throw _interpreterExceptionsFactory.VariableAlreadyDeclared(variableName, line, column);
        }
            
        var value = VisitExpression(context.expression());

        var variable = new Variable(variableName, value, GetBasicType(value), isConstant, GetCurrentFunctionName());

        _variables.Add(variable);

        return End;
    }

    public override object VisitAssignment(MoistParser.AssignmentContext context)
    {
        var variableName = context.Identificator().GetText();
        var value = Visit(context.expression());

        if (TryGetVariable(variableName, out var variable))
        {
            if (variable.IsConstant)
            {
                throw _interpreterExceptionsFactory.CanNotAssignToConstant(variableName, 
                    context.expression().Start.Line, 
                    context.expression().Start.Column);
            }
                
            if (variable.BasicType != GetBasicType(value))
            {
                throw _interpreterExceptionsFactory.ValueOfTypeCanNotBeAssigned(variable.BasicType, 
                    GetBasicType(value), 
                    context.expression().Start.Line, 
                    context.expression().Start.Column);
            }
                
            variable.Value = value;
        }
        else
        {
            throw _interpreterExceptionsFactory.VariableNotDeclared(variableName, context.Start.Line, context.Start.Column);
        }

        return End;
    }
        
    public override object VisitIndexAssignment(MoistParser.IndexAssignmentContext context)
    {
        var variableName = context.Identificator().GetText();
        var index = Visit(context.index());
        var value = Visit(context.expression());

        if (TryGetVariable(variableName, out var variable))
        {
            if (variable.IsConstant)
            {
                throw _interpreterExceptionsFactory.CanNotAssignToConstant(variableName, 
                    context.expression().Start.Line, 
                    context.expression().Start.Column);
            }

            if (variable.BasicType == BasicType.Array)
            {
                var arrVariable = (List<object>)variable.Value;
                arrVariable[(int)index] = value;
                    
                variable.Value = arrVariable;
            }
            else if (variable.BasicType == BasicType.String)
            {
                var arrVariable = (string)variable.Value;
                arrVariable = arrVariable.Remove((int)index, 1);
                arrVariable = arrVariable.Insert((int)index, value.ToString()!);
                    
                variable.Value = arrVariable;
            }
                
        }
        else
        {
            throw _interpreterExceptionsFactory.VariableNotDeclared(variableName, context.Start.Line, context.Start.Column);
        }

        return End;
    }

    public override object VisitExpression(MoistParser.ExpressionContext context)
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
                throw _interpreterExceptionsFactory.ExpressionIsNotBoolean(context.multiplyExpression(0).GetText(), 
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
            throw _interpreterExceptionsFactory.ExpressionIsNotBoolean(context.multiplyExpression(0).GetText(), 
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

    public override object VisitMultiplyExpression(MoistParser.MultiplyExpressionContext context)
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

    private object VisitComparison(MoistParser.ExpressionContext context, object left, object right, string sign)
    {
        var leftType = GetBasicType(left);
        var rightType = GetBasicType(right);
            
        if (leftType != rightType)
        {
            throw _interpreterExceptionsFactory.DifferentTypesComparison(leftType.ToString(), rightType.ToString(), 
                context.Start.Line, 
                context.Start.Column);
        }
            
        // int comparison
        if (leftType == BasicType.Integer)
        {
            return sign switch
            {
                ">" => (int)left > (int)right,
                ">=" => (int)left >= (int)right,
                "<" => (int)left < (int)right,
                "<=" => (int)left <= (int)right,
                "==" => left.Equals(right),
                "!=" => !left.Equals(right),
                _ => throw _interpreterExceptionsFactory.UnknownOperator(sign, 
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
                _ => throw _interpreterExceptionsFactory.UnknownOperator(sign, 
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
                _ => throw _interpreterExceptionsFactory.UnknownOperator(sign, 
                    context.comparisonRightSide().comparisonSign().Start.Line, 
                    context.comparisonRightSide().comparisonSign().Start.Column)
            };
        }
            
        if (leftType == BasicType.Boolean)
        {
            return sign switch
            {
                "==" => left.Equals(right),
                "!=" => !left.Equals(right),
                "&&" => (bool)left && (bool)right,
                "||" => (bool)left || (bool)right,
                _ => throw _interpreterExceptionsFactory.UnknownOperator(sign, 
                    context.comparisonRightSide().comparisonSign().Start.Line, 
                    context.comparisonRightSide().comparisonSign().Start.Column)
            };
        }

        return End;
    }
        
    public override object VisitValue(MoistParser.ValueContext context)
    {
        if (context.basicTypeValue() is not null)
        {
            if (context.basicTypeValue().Unit() != null)
            {
                return Unit.Value;
            }
                
            if (context.basicTypeValue().Integer() != null)
            {
                return int.Parse(context.basicTypeValue().Integer().GetText());
            }
                
            if (context.basicTypeValue().Double() != null)
            {
                return decimal.Parse(context.basicTypeValue().Double().GetText(), CultureInfo.InvariantCulture);
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
        }

        if (context.arrayIndexing() != null)
        {
            return VisitArrayIndexing(context.arrayIndexing());
        }

        if (context.functionCall() != null)
        {
            return VisitFunctionCall(context.functionCall());
        }

        if (context.expression() != null)
        {
            return Visit(context.expression());
        }
            
        if (context.Identificator() != null)
        {
            var variableName = context.Identificator().GetText();
                
            if (TryGetVariable(variableName, out var variable))
            {
                return variable.Value;
            }

            throw _interpreterExceptionsFactory.VariableNotDeclared(variableName, context.Start.Line, context.Start.Column);
        }

        return End;
    }

    public override object VisitIfStatement(MoistParser.IfStatementContext context)
    {
        var condition = Visit(context.expression());

        if (condition is not bool boolCondition)
        {
            throw _interpreterExceptionsFactory.ExpressionIsNotBoolean(context.expression().GetText(), 
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

        return End;
    }

    public override object VisitWhileStatement(MoistParser.WhileStatementContext context)
    {
        var condition = Visit(context.expression());

        if (condition is not bool boolCondition)
        {
            throw _interpreterExceptionsFactory.ExpressionIsNotBoolean(context.expression().GetText(), 
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

        return End;
    }

    public override object VisitForStatement(MoistParser.ForStatementContext context)
    {
        var declaration = context.declaration();
        if (declaration is null)
        {
            throw _interpreterExceptionsFactory.ForLoopVariableNotDeclared(context.GetText(), 
                context.Start.Line, 
                context.Start.Column);
        }
        VisitDeclaration(declaration);
        
        var expression = context.expression();
            
        if (expression is null)
        {
            throw _interpreterExceptionsFactory.ForLoopStepNotDeclared(context.GetText(), 
                context.Start.Line, 
                context.Start.Column);
        }

        var condition = Visit(expression);
            
        if (condition is null)
        {
            throw _interpreterExceptionsFactory.ForLoopConditionNotDeclared(context.GetText(), 
                context.Start.Line, 
                context.Start.Column);
        }

        if (condition is not bool boolCondition)
        {
            throw _interpreterExceptionsFactory.ExpressionIsNotBoolean(expression.GetText(), 
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
                throw _interpreterExceptionsFactory.ForLoopStepNotDeclared(context.expression().GetText(), 
                    context.Start.Line, 
                    context.Start.Column);
            }
                
            VisitAssignment(step);
            boolCondition = (bool)Visit(expression);
        }

        return End;
    }

    public override object VisitForEachStatement(MoistParser.ForEachStatementContext context)
    {
        var variableName = context.forEachVariable().GetText();
        Variable newVariable = default!;
        if (!TryGetVariable(variableName, out _))
        {
            newVariable = new Variable(variableName, End, BasicType.Unknown, false, GetCurrentFunctionName());
        }

        var collection = context.forEachCollection();
        var collectionValue = VisitExpression(collection.expression());
        var collectionType = GetBasicType(collectionValue);

        if (collectionType is not (BasicType.Array or BasicType.String))
        {
            throw _interpreterExceptionsFactory.UnsupportedTypeAsCollection(collectionType.ToString(), 
                collection.expression().Start.Line, 
                collection.expression().Start.Column);
        }

        var statements = context.statement();
        if (collectionType is BasicType.Array)
        {
            var array = (List<object>) collectionValue;
            foreach (var element in array)
            {
                if (!TryGetVariable(variableName, out var variable))
                {
                    newVariable.Value = element;
                    newVariable.BasicType = GetBasicType(element);
                    _variables.Add(newVariable);
                    variable = newVariable;
                }
                variable.Value = element;
                foreach (var statement in statements)
                {
                    VisitStatement(statement);
                }
            }
        } 
        else
        {
            var array = (string) collectionValue;
            foreach (var element in array)
            {
                if (!TryGetVariable(variableName, out var variable))
                {
                    newVariable.Value = element;
                    newVariable.BasicType = BasicType.String;
                    _variables.Add(newVariable);
                    variable = newVariable;
                }
                variable.Value = element;
                foreach (var statement in statements)
                {
                    VisitStatement(statement);
                }
            }
        }

        return End;
    }

    public override object VisitFunctionCall(MoistParser.FunctionCallContext context)
    {
        var functionName = context.Identificator().GetText();
        var argumentsValues = new List<object>();
            
        if (context.expression().Length > 0)
        {
            argumentsValues.AddRange(
                context.expression().Select(Visit)
            );
        }

        var userFunc = _functions
            .FirstOrDefault(x => x.Name == functionName && x.Arguments.Count == argumentsValues.Count);
            
        if (userFunc is not null)
        {
            _recursionDepth++;
                
            for (var i = 0; i < userFunc.Arguments.Count; i++)
            {
                var variable = new Variable(userFunc.Arguments[i], argumentsValues[i],
                    GetBasicType(argumentsValues[i]), false, functionName + _recursionDepth);

                _variables.Add(variable);
            }
                
            _visitedFunctions.Push(functionName);
                
            foreach (var statement in userFunc.Statements)
            {
                var ret = Visit(statement);

                if (ret != Unit.Value && _functionReturnType != BasicType.Unknown)
                {
                    var retValue = _functionReturnValue;
                    ResetScope();
                        
                    return retValue;
                }
            }

            ResetScope();

            return Unit.Value;
        }

        var function = InvokeStandardLibraryFunction(functionName, 
            argumentsValues.ToArray(), 
            context.Start.Line, 
            context.Start.Column)!;

        return function;
    }

    public override object VisitFunctionDeclaration(MoistParser.FunctionDeclarationContext context)
    {
        var functionName = context.Identificator().GetText();
        var parameters = 
            context.functionParameters()?.Identificator().Select(x => x.GetText()).ToList()
            ?? new List<string>();

        var i = 0;
        foreach (var parameter in parameters)
        {
            if (TryGetVariable(parameter, out _))
            {
                throw _interpreterExceptionsFactory.GlobalVariableWithSameNameAlreadyDeclared(parameter, 
                    context.Start.Line, 
                    context.Start.Column + "func ".Length + functionName.Length + 1 + i);
            }

            i += parameter.Length + 1;
            i++;
        }

        var function = new Function(functionName, parameters, context.statement().ToList());
        if (_functions.Any(x => x.Name == functionName && x.Arguments.Count == parameters.Count))
        {
            throw _interpreterExceptionsFactory.FunctionAlreadyDeclared(functionName, parameters.Count,
                context.Start.Line, context.Start.Column);
        }

        _functions.Add(function);
                
        return End;
    }

    public override object VisitArrayIndexing(MoistParser.ArrayIndexingContext context)
    {
        var indexValue = 0;
            
        // Index
        var index = context.index();
        if (index.Identificator() != null)
        {
            var variableName = index.Identificator().GetText();
            TryGetVariable(variableName, out var variable);

            if (variable.BasicType != BasicType.Integer)
            {
                throw _interpreterExceptionsFactory.ArrayIndexerMustBeInteger(variable.BasicType, 
                    index.Start.Line, 
                    index.Start.Column);
            }
                
            indexValue = (int)variable.Value;
        }
        else if (index.expression() != null)
        {
            var value = VisitExpression(index.expression());
            var valueType = GetBasicType(value);

            if (valueType != BasicType.Integer)
            {
                throw _interpreterExceptionsFactory.ArrayIndexerMustBeInteger(valueType, 
                    index.Start.Line, 
                    index.Start.Column);
            }
                
            indexValue = (int)value;
        }
            
        // Array 
        if (context.arrayOrVariable().Identificator() != null)
        {
            var variableName = context.arrayOrVariable().Identificator().GetText();
            TryGetVariable(variableName, out var variable);

            if (variable.BasicType == BasicType.String)
            {
                return ((string)variable.Value)[indexValue].ToString();
            }

            return ((List<object>)variable.Value)[indexValue];
        }
        if (context.arrayOrVariable().array() != null)
        {
            var array = new List<object>();
            foreach (var value in context.arrayOrVariable().array().expression())
            {
                array.Add(VisitExpression(value));
            }

            return array[indexValue];
        }

        return End;
    }

    public override object VisitReturn(MoistParser.ReturnContext context)
    {
        if (_visitedFunctions.Peek() == "$global")
        {
            throw _interpreterExceptionsFactory.ReturnOutsideFunction(context.Start.Line, context.Start.Column);
        }
        
        var value = VisitExpression(context.expression());
            
        _functionReturnValue = value;
        _functionReturnType = GetBasicType(value);
            
        return value;
    }

    #region Helpers
        
    private void ResetScope()
    {
        _functionReturnValue = End;
        _functionReturnType = BasicType.Unknown;
            
        foreach (var variable in 
                 _variables
                     .Where(x => x.Caller == GetCurrentFunctionName()).ToList())
        {
            _variables.Remove(variable);
        }
            
        _recursionDepth--;

        if (GetCurrentFunctionName() != "$global")
        {
            _visitedFunctions.Pop();
        }
    }

    private string GetCurrentFunctionName()
    {
        return _visitedFunctions.Peek() + _recursionDepth;
    }
        
    private bool TryGetVariable(string name, out Variable variable)
    {
        var variableMaybe = _variables
            .FirstOrDefault(x => x.Name == name && x.Caller == GetCurrentFunctionName());
            
        if (variableMaybe is null)
        {
            variable = new Variable("", End, BasicType.Unknown, false, "");
            return false;
        }

        variable = variableMaybe;
        return true;
    }
        
    public static BasicType GetBasicType(object value)
    {
        return value switch
        {
            Unit => BasicType.Unit,
            int => BasicType.Integer,
            decimal => BasicType.Double,
            string => BasicType.String,
            bool => BasicType.Boolean,
            List<object> => BasicType.Array,
            _ => BasicType.Unknown
        };
    }

    private static BasicType GetBasicTypeByType(Type type)
    {
        return type switch
        {
            not null when type == typeof(Unit) => BasicType.Unit,
            not null when type == typeof(int) => BasicType.Integer,
            not null when type == typeof(decimal) => BasicType.Double,
            not null when type == typeof(string) => BasicType.String,
            not null when type == typeof(bool) => BasicType.Boolean,
            not null when type == typeof(List<object>) => BasicType.Array,
            _ => BasicType.Unknown
        };
    }
        
    private object? InvokeStandardLibraryFunction(string functionName, object[] arguments, int line, int column)
    {
        var standardLibraryType = typeof(Functions);
        var argumentsTypes = arguments.Select(GetBasicType).ToList();
            
        var methods = standardLibraryType
            .GetMethods()
            .Where(method => method.Name == functionName && method.GetParameters().Length == arguments.Length)
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
            throw _interpreterExceptionsFactory.FunctionNotDeclaredWithArgumentTypes(functionName, argumentsTypes, line,
                column);
        }

        try
        {
            return method.Invoke(null, arguments);
        }
        catch
        {
            throw _interpreterExceptionsFactory.FunctionNotDeclaredWithArgumentTypes(functionName, argumentsTypes, line, column);
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
                    _ => throw _interpreterExceptionsFactory.UnknownOperator(op, line, column)
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
                    _ => throw _interpreterExceptionsFactory.UnknownOperator(op, line, column)
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
                    _ => throw _interpreterExceptionsFactory.UnknownOperator(op, line, column)
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
                    _ => throw _interpreterExceptionsFactory.UnknownOperator(op, line, column)
                };
            }
                
            if (left is string leftStr && right is string rightStr)
            {
                return op switch
                {
                    "+" => leftStr + rightStr,
                    _ => throw _interpreterExceptionsFactory.UnknownOperator(op, line, column)
                };
            }
                
            if (left is string str && right is int @int)
            {
                return op switch
                {
                    "+" => str + @int,
                    "*" => string.Concat(Enumerable.Repeat(str, @int)),
                    _ => throw _interpreterExceptionsFactory.UnknownOperator(op, line, column)
                };
            }
                
            if (left is int int1 && right is string str1)
            {
                return op switch
                {
                    "+" => int1 + str1,
                    "*" => string.Concat(Enumerable.Repeat(str1, int1)),
                    _ => throw _interpreterExceptionsFactory.UnknownOperator(op, line, column)
                };
            }
        }
        catch
        {
            throw _interpreterExceptionsFactory.OperatorNotSupportedForTypes(op, 
                GetBasicType(left), 
                GetBasicType(right), 
                line, 
                column);
        }

        throw _interpreterExceptionsFactory.OperatorNotSupportedForTypes(op, 
            GetBasicType(left), 
            GetBasicType(right), 
            line, 
            column);
    }

    #endregion
}