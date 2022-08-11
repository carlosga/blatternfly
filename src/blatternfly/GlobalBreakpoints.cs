namespace Blatternfly;

internal static class GlobalBreakpoints
{
    internal static readonly int ExtraSmall  = 0;
    internal static readonly int Small       = 576;
    internal static readonly int Medium      = 768;
    internal static readonly int Large       = 992;
    internal static readonly int ExtraLarge  = 1200;
    internal static readonly int ExtraLarge2 = 1450;

    internal static Breakpoint? GetHorizontalBreakpoint(int? width)
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

    internal static Breakpoint? GetVerticalBreakpoint(int? height)
    {
        return null;
    }

    internal static string GetBreakpointString(int? width)
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

    internal static string GetVerticalBreakpointString(int? height)
    {
        return null;
    }
}
