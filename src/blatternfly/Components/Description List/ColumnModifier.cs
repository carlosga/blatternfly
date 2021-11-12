namespace Blatternfly.Components;

public sealed class ColumnModifier : FormatBreakpointMods<ColumnModifiers?>
{
    protected override string Prefix => "m";
    
    protected override string ToString(ColumnModifiers? state)
    {
        return state switch
        {
            ColumnModifiers.Col1 => "1-col",
            ColumnModifiers.Col2 => "2-col",
            ColumnModifiers.Col3 => "3-col",
            _                    => null
        };            
    }
}
