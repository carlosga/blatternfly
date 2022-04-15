namespace Blatternfly.Layouts;

public sealed class FlexGrowModifiers : FormatBreakpointMods<bool?>
{
    protected override string Prefix => "m";

    protected override string ToString(bool? value)
    {
        return value.HasValue && value.Value ? "grow" : null;
    }
}
