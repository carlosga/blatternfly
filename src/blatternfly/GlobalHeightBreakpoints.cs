namespace Blatternfly;

internal static class GlobalHeightBreakpoints
{
    internal const int ExtraSmall  = 0;
    internal const int Small       = 0;
    internal const int Medium      = 40;    // 40rem
    internal const int Large       = 48;    // 48rem
    internal const int ExtraLarge  = 60;    // 60rem
    internal const int ExtraLarge2 = 80;    // 80rem

    internal static Breakpoint? GetBreakpoint(int? height)
    {
        return height switch
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

    internal static string GetBreakpointString(int? height)
    {
        return height switch
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
