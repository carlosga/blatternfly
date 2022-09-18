namespace Blatternfly.Layouts;

/// <summary>Flex full width modifiers.</summary>
public sealed class FlexFullWidthModifiers : FormatBreakpointMods<bool?>
{
    protected override string Prefix => "m";

    protected override string ToString(bool? value)
    {
        return value.HasValue && value.Value ? "full-width" : null;
    }
}
