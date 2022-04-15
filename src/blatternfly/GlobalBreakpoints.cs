namespace Blatternfly;

public static class GlobalBreakpoints
{
    public static readonly int ExtraSmall  = 0;
    public static readonly int Small       = 576;
    public static readonly int Medium      = 768;
    public static readonly int Large       = 992;
    public static readonly int ExtraLarge  = 1200;
    public static readonly int ExtraLarge2 = 1450;

    public static Breakpoint? GetBreakpoint(int? width)
    {
        return width switch
        {
            null    => null,
            >= 1450 => Breakpoint.ExtraLarge2,
            >= 1200 => Breakpoint.ExtraLarge,
            >= 992  => Breakpoint.Large,
            >= 768  => Breakpoint.Medium,
            >= 576  => Breakpoint.Small,
            _       => Breakpoint.Default
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
