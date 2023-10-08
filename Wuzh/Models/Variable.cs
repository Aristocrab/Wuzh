using Wuzh.Enums;
using Wuzh.Exceptions;

namespace Wuzh.Models;

public class Variable
{
    public string Name { get; }

    private object _value;
    public object Value
    {
        get => _value;
        set
        {
            if (IsConstant)
            {
                throw new InterpreterException($"Cannot assign value to constant variable '{Name}'");
            }
            
            _value = value;
        }
    }

    public BasicType BasicType { get; set; }
    
    public bool IsConstant { get; }
    public int FunctionDepth { get; }
    public int ScopeDepth { get; }

    public Variable(string name, object value, BasicType basicType, bool isConstant, int functionDepth, int scopeDepth)
    {
        Name = name;
        _value = value;
        BasicType = basicType;
        IsConstant = isConstant;
        FunctionDepth = functionDepth;
        ScopeDepth = scopeDepth;
    }
}