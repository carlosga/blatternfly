namespace Blatternfly;

internal static class GlobalWidthBreakpoints
{
    internal const int ExtraSmall  = 0;
    internal const int Small       = 576;
    internal const int Medium      = 768;
    internal const int Large       = 992;
    internal const int ExtraLarge  = 1200;
    internal const int ExtraLarge2 = 1450;

    internal static Breakpoint? GetBreakpoint(int? width)
    {
        return width switch
        {
            null           => null,
            >= ExtraLarge2 => Breakpoint.ExtraLarge2,
            >= ExtraLarge  => Breakpoint.ExtraLarge,
            >= Large       => Breakpoint.Large,
            >= Medium      => Breakpoint.Medium,
            >= Small       => Breakpoint.Small,
            _              => Breakpoint.Default
        };
    }

    internal static string GetBreakpointString(int? width)
    {
        return width switch
        {
            null            => null,
            >= ExtraLarge2  => "2xl",
            >= ExtraLarge   => "xl",
            >= Large        => "lg",
            >= Medium       => "md",
            >= Small        => "sm",
            _               => "default"
        };
    }
}
