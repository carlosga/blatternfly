namespace Blatternfly.Layouts;

public sealed class AlignContentModifiers : FormatBreakpointMods<AlignContent?>
{
    protected override string Prefix => "m-align-content";

    protected override string ToString(AlignContent? state)
    {
        return state switch
        {
            AlignContent.FlexStart    => "flex-start",
            AlignContent.FlexEnd      => "flex-end",
            AlignContent.Center       => "center",
            AlignContent.Stretch      => "stretch",
            AlignContent.SpaceBetween => "space-between",
            AlignContent.SpaceAround  => "space-around",
            _                         => null
        };
    }
}
