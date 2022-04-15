namespace Blatternfly.Layouts;

public sealed class FlexSpacerModifiers : FormatBreakpointMods<FlexSpacer?>
{
    protected override string Prefix => "m-spacer";

    protected override string ToString(FlexSpacer? value)
    {
        return value switch
        {
            FlexSpacer.None        => "none",
            FlexSpacer.ExtraSmall  => "xs",
            FlexSpacer.Small       => "sm",
            FlexSpacer.Medium      => "md",
            FlexSpacer.Large       => "lg",
            FlexSpacer.ExtraLarge  => "xl",
            FlexSpacer.ExtraLarge2 => "2xl",
            FlexSpacer.ExtraLarge3 => "3xl",
            FlexSpacer.ExtraLarge4 => "4xl",
            _                      => null
        };
    }
}
