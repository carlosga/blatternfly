namespace Blatternfly;

public static class GlobalBreakpoints
{
    public static readonly int ExtraSmall  = 0;
    public static readonly int Small       = 576;
    public static readonly int Medium      = 768;
    public static readonly int Large       = 992;
    public static readonly int ExtraLarge  = 1200;
    public static readonly int ExtraLarge2 = 1450;

    public static Breakpoints? GetBreakpoint(int? width)
    {
        return width switch
        {
            null    => null,
            >= 1450 => Breakpoints.ExtraLarge2,
            >= 1200 => Breakpoints.ExtraLarge,
            >= 992  => Breakpoints.Large,
            >= 768  => Breakpoints.Medium,
            >= 576  => Breakpoints.Small,
            _       => Breakpoints.Default
        };
    }

    public static string GetBreakpointString(int? width)
    {
        return width switch
        {
            null    => null,
            >= 1450 => "2xl",
            >= 1200 => "xl",
            >= 992  => "lg",
            >= 768  => "md",
            >= 576  => "sm",
            _       => "default"
        };
    }
}
