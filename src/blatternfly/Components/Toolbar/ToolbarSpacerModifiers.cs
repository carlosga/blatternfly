namespace Blatternfly.Components;

public sealed class ToolbarSpacerModifiers : FormatBreakpointMods<ToolbarSpacer?>
{
    protected override string Prefix => "m-spacer";

    protected override string ToString(ToolbarSpacer? value)
    {
        return value switch
        {
            ToolbarSpacer.None        => "none",
            ToolbarSpacer.Small       => "sm",
            ToolbarSpacer.Medium      => "md",
            ToolbarSpacer.Large       => "lg",
            ToolbarSpacer.ExtraLarge  => "xl",
            ToolbarSpacer.ExtraLarge2 => "2xl",
            _                         => null
        };
    }
}
