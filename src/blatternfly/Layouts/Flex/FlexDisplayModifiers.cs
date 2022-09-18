namespace Blatternfly.Layouts;

/// <summary>Flex display modifiers.</summary>
public sealed class FlexDisplayModifiers : FormatBreakpointMods<FlexDisplay?>
{
    protected override string Prefix => "m";

    protected override string ToString(FlexDisplay? value)
    {
        return value switch
        {
            FlexDisplay.Flex       => "flex",
            FlexDisplay.InlineFlex => "inline-flex",
            _                      => null
        };
    }
}
