namespace Blatternfly.Layouts;

public sealed class FlexSpacer : FormatBreakpointMods<FlexSpacers?>
{
    protected override string Prefix => "m-spacer";

    protected override string ToString(FlexSpacers? value)
    {
        return value switch
        {
            FlexSpacers.None        => "none",
            FlexSpacers.ExtraSmall  => "xs",
            FlexSpacers.Small       => "sm",
            FlexSpacers.Medium      => "md",
            FlexSpacers.Large       => "lg",
            FlexSpacers.ExtraLarge  => "xl",
            FlexSpacers.ExtraLarge2 => "2xl",
            FlexSpacers.ExtraLarge3 => "3xl",
            FlexSpacers.ExtraLarge4 => "4xl",
            _                       => null
        };
    }
}
