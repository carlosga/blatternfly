namespace Blatternfly;

public sealed class Visibility : FormatBreakpointMods<Visibilities?>
{
    protected override string Prefix => "m";

    protected override string ToString(Visibilities? state)
        => state == Visibilities.Hidden ? "hidden" : "visible";
}
