namespace Blatternfly.Components;

public sealed class MastheadDisplay : FormatBreakpointMods<MastheadDisplayType?>
{
    protected override string Prefix => "m-display";

    protected override string ToString(MastheadDisplayType? state)
    {
        return state is MastheadDisplayType.Inline ? "inline" : "stack";
    }
}
