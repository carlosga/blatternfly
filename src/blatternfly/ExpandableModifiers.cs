namespace Blatternfly;

/// <summary>Expandable modifier.s</summary>
public sealed class ExpandableModifiers : FormatBreakpointMods<Expandable?>
{
    protected override string Prefix => "m";

    protected override string ToString(Expandable? state)
        => state is Expandable.Expandable ? "expandable" : "nonExpandable";
}
