namespace Blatternfly.Components;

 /// <summary>
 /// Description list column modifiers.
 /// </summary>
public sealed class DescriptionListColumnModifiers : FormatBreakpointMods<DescriptionListColumn?>
{
    protected override string Prefix => "m";

    protected override string ToString(DescriptionListColumn? state)
    {
        return state switch
        {
            DescriptionListColumn.Col1 => "1-col",
            DescriptionListColumn.Col2 => "2-col",
            DescriptionListColumn.Col3 => "3-col",
            _                          => null
        };
    }
}
