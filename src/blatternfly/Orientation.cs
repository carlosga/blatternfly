namespace Blatternfly;

public sealed class Orientation : FormatBreakpointMods<Orientations?>
{
    protected override string Prefix => "m";

    protected override string ToString(Orientations? state) => state == Orientations.Vertical ? "vertical" : "horizontal";
}
