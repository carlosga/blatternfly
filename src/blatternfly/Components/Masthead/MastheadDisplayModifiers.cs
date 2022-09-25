namespace Blatternfly.Components;

/// <summary>Masthead display modifiers.</summary>
public sealed class MastheadDisplayModifiers : FormatBreakpointMods<MastheadDisplay?>
{
    protected override string Prefix => "m-display";

    protected override string ToString(MastheadDisplay? state)
        => state is MastheadDisplay.Inline ? "inline" : "stack";
}
