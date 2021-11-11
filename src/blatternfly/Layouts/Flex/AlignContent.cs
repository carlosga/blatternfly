namespace Blatternfly.Layouts;

public sealed class AlignContent : FormatBreakpointMods<AlignContents?>
{
    protected override string Prefix => "m-align-content";

    protected override string ToString(AlignContents? state)
    {
        return state switch
        {
            AlignContents.FlexStart     => "flex-start",
            AlignContents.FlexEnd       => "flex-end",
            AlignContents.Center        => "center",
            AlignContents.Stretch       => "stretch",
            AlignContents.SpaceBetween  => "space-between",
            AlignContents.SpaceAround   => "space-around",
            _                           => null
        };
    }
}
