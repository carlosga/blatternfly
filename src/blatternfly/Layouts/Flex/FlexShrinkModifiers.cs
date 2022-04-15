namespace Blatternfly.Layouts;

public sealed class FlexShrinkModifiers : FormatBreakpointMods<bool?>
{
    protected override string Prefix => "m";

    protected override string ToString(bool? value)
    {
        return value.HasValue && value.Value ? "shrink" : null;
    }
}
