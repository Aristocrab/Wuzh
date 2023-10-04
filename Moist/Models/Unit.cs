namespace Moist.Models;

public sealed class Unit
{
    public static readonly Unit Value = new();

    public override string ToString()
    {
        return "unit";
    }
}