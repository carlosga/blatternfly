namespace Blatternfly.Components;

public sealed class MastheadDisplayModifiers : FormatBreakpointMods<MastheadDisplay?>
{
    protected override string Prefix => "m-display";

    protected override string ToString(MastheadDisplay? state)
    {
        return state is MastheadDisplay.Inline ? "inline" : "stack";
    }
}
