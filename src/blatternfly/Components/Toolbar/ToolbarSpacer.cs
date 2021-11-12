namespace Blatternfly.Components;

public sealed class ToolbarSpacer : FormatBreakpointMods<ToolbarSpacers?>
{
    protected override string Prefix => "m-spacer";

    protected override string ToString(ToolbarSpacers? value)
    {
        return value switch
        {
            ToolbarSpacers.None        => "none",
            ToolbarSpacers.Small       => "sm",
            ToolbarSpacers.Medium      => "md",
            ToolbarSpacers.Large       => "lg",
            ToolbarSpacers.ExtraLarge  => "xl",
            ToolbarSpacers.ExtraLarge2 => "2xl",
            _                          => null
        };
    }
}
