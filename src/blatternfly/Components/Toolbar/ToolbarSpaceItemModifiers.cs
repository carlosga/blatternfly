namespace Blatternfly.Components;

public sealed class ToolbarSpaceItemModifiers : FormatBreakpointMods<ToolbarSpaceItem?>
{
    protected override string Prefix => "m-space-items";

    protected override string ToString(ToolbarSpaceItem? state)
    {
        return state switch
        {
            ToolbarSpaceItem.None        => "none",
            ToolbarSpaceItem.Small       => "sm",
            ToolbarSpaceItem.Medium      => "md",
            ToolbarSpaceItem.Large       => "lg",
            ToolbarSpaceItem.ExtraLarge  => "xl",
            ToolbarSpaceItem.ExtraLarge2 => "2xl",
            _                            => null
        };
    }
}
