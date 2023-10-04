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
                throw new ParserException($"Cannot assign value to constant variable '{Name}'");
            }
            
            _value = value;
        }
    }

    public BasicType BasicType { get; }
    
    public bool IsConstant { get; }
    
    public Variable(string name, object value, BasicType basicType, bool isConstant)
    {
        Name = name;
        _value = value;
        BasicType = basicType;
        IsConstant = isConstant;
    }
}