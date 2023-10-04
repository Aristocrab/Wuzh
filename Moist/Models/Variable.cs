using Moist.Enums;
using Moist.Exceptions;

namespace Moist.Models;

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
    
    public string Caller { get; }
    
    public Variable(string name, object value, BasicType basicType, bool isConstant, string caller = "$global")
    {
        Name = name;
        _value = value;
        BasicType = basicType;
        IsConstant = isConstant;
        Caller = caller;
    }
}