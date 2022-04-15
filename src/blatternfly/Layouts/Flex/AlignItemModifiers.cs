namespace Blatternfly.Layouts;

public sealed class AlignItemModifiers : FormatBreakpointMods<AlignItem?>
{
    protected override string Prefix => "m-align-items";

    protected override string ToString(AlignItem? value)
    {
        return value switch
        {
            AlignItem.FlexStart => "flex-start",
            AlignItem.FlexEnd   => "flex-end",
            AlignItem.Center    => "center",
            AlignItem.Stretch   => "stretch",
            AlignItem.Baseline  => "baseline",
            _                   => null
        };
    }
}
