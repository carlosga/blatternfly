namespace Blatternfly;

/// <summary>Padding modifiers.</summary>
public sealed class PaddingModifiers : FormatBreakpointMods<Padding?>
{
    protected override string Prefix => "m";

    protected override string ToString(Padding? state)
    {
        return state is Padding.Padding ? "padding" : "no-padding";
    }
}
