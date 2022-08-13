namespace Blatternfly.Components;

public sealed class StickyPositionModifiers : FormatBreakpointMods<StickyPosition?>
{
    protected override string Prefix => "m-sticky";
    protected override string Suffix => "-height";

    protected override string ToString(StickyPosition? state)
    {
        return state switch
        {
            StickyPosition.Top    => "top",
            StickyPosition.Bottom => "bottom",
            _                     => null
        };
    }
}
