namespace Blatternfly.Layouts;

/// <summary>Flex direction modifiers.</summary>
public sealed class FlexDirectionModifiers : FormatBreakpointMods<FlexDirection?>
{
    protected override string Prefix => "m";

    protected override string ToString(FlexDirection? value)
    {
        return value switch
        {
            FlexDirection.Column        => "column",
            FlexDirection.ColumnReverse => "column-reverse",
            FlexDirection.Row           => "row",
            FlexDirection.RowReverse    => "row-reverse",
            _                           => null
        };
    }
}
