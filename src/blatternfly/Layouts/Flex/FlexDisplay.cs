namespace Blatternfly.Layouts;

public sealed class FlexDisplay : FormatBreakpointMods<FlexDisplays?>
{
    protected override string Prefix => "m";

    protected override string ToString(FlexDisplays? value)
    {
        return value switch
        {
            FlexDisplays.Flex       => "flex",
            FlexDisplays.InlineFlex => "inline-flex",
            _                       => null
        };
    }
}
