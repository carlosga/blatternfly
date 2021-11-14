namespace Blatternfly.Layouts;

public sealed class AlignSelf : FormatBreakpointMods<AlignSelfs?>
{
    protected override string Prefix => "m-align-self";

    protected override string ToString(AlignSelfs? value)
    {
        return value switch
        {
            AlignSelfs.FlexStart => "flex-start",
            AlignSelfs.FlexEnd   => "flex-end",
            AlignSelfs.Center    => "center",
            AlignSelfs.Stretch   => "stretch",
            AlignSelfs.Baseline  => "baseline",
            _                    => null
        };
    }
}
