namespace Blatternfly.Layouts;

public sealed class FlexSpaceItem : FormatBreakpointMods<FlexSpaceItems?>
{
    protected override string Prefix => "m-space-items";

    protected override string ToString(FlexSpaceItems? value)
    {
        return value switch
        {
            FlexSpaceItems.None        => "none",
            FlexSpaceItems.ExtraSmall  => "xs",
            FlexSpaceItems.Small       => "sm",
            FlexSpaceItems.Medium      => "md",
            FlexSpaceItems.Large       => "lg",
            FlexSpaceItems.ExtraLarge  => "xl",
            FlexSpaceItems.ExtraLarge2 => "2xl",
            FlexSpaceItems.ExtraLarge3 => "3xl",
            FlexSpaceItems.ExtraLarge4 => "4xl",
            _                          => null
        };
    }
}
