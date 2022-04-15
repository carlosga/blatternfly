namespace Blatternfly.Layouts;

public sealed class AlignSelfModifiers : FormatBreakpointMods<AlignSelf?>
{
    protected override string Prefix => "m-align-self";

    protected override string ToString(AlignSelf? value)
    {
        return value switch
        {
            AlignSelf.FlexStart => "flex-start",
            AlignSelf.FlexEnd   => "flex-end",
            AlignSelf.Center    => "center",
            AlignSelf.Stretch   => "stretch",
            AlignSelf.Baseline  => "baseline",
            _                   => null
        };
    }
}
