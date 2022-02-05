namespace Blatternfly;

public sealed class Expandable : FormatBreakpointMods<Expandables?>
{
    protected override string Prefix => "m";

    protected override string ToString(Expandables? state)
        => state == Expandables.Expandable ? "expandable" : "nonExpandable";
}
