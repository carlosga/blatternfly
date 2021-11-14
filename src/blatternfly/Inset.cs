namespace Blatternfly;

public sealed class Inset : FormatBreakpointMods<Insets?>
{
    protected override string Prefix => "m-inset";

    protected override string ToString(Insets? state)
    {
        return state switch
        {
            Insets.None        => "none",
            Insets.ExtraSmall  => "xs",
            Insets.Small       => "sm",
            Insets.Medium      => "md",
            Insets.Large       => "lg",
            Insets.ExtraLarge  => "xl",
            Insets.ExtraLarge2 => "2xl",
            Insets.ExtraLarge3 => "3xl",
            _                  => null
        };
    }
}
