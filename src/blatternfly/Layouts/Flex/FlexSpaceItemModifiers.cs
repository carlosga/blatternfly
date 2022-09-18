namespace Blatternfly.Layouts;

/// <summary>Flex space item modifiers.</summary>
public sealed class FlexSpaceItemModifiers : FormatBreakpointMods<FlexSpaceItem?>
{
    protected override string Prefix => "m-space-items";

    protected override string ToString(FlexSpaceItem? value)
    {
        return value switch
        {
            FlexSpaceItem.None        => "none",
            FlexSpaceItem.ExtraSmall  => "xs",
            FlexSpaceItem.Small       => "sm",
            FlexSpaceItem.Medium      => "md",
            FlexSpaceItem.Large       => "lg",
            FlexSpaceItem.ExtraLarge  => "xl",
            FlexSpaceItem.ExtraLarge2 => "2xl",
            FlexSpaceItem.ExtraLarge3 => "3xl",
            FlexSpaceItem.ExtraLarge4 => "4xl",
            _                         => null
        };
    }
}
