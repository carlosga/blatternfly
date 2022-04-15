namespace Blatternfly;

public sealed class InsetModifiers : FormatBreakpointMods<Inset?>
{
    protected override string Prefix => "m-inset";

    protected override string ToString(Inset? state)
    {
        return state switch
        {
            Inset.None        => "none",
            Inset.ExtraSmall  => "xs",
            Inset.Small       => "sm",
            Inset.Medium      => "md",
            Inset.Large       => "lg",
            Inset.ExtraLarge  => "xl",
            Inset.ExtraLarge2 => "2xl",
            Inset.ExtraLarge3 => "3xl",
            _                 => null
        };
    }
}
