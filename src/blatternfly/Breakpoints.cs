namespace Blatternfly;

public enum Breakpoints
{
    Default,
    Small,
    Medium,
    Large,
    ExtraLarge,
    ExtraLarge2
}

public sealed class BreakpointMods : FormatBreakpointMods<Breakpoints?>
{
    public static BreakpointMods FromBreakpoint(Breakpoints breakpoint)
    {
        var mods = new BreakpointMods();

        if (breakpoint is Breakpoints.Default)
        {
            mods.Default = Breakpoints.Default;
        }
        else if (breakpoint is Breakpoints.Small)
        {
            mods.Small = Breakpoints.Small;
        }
        else if (breakpoint is Breakpoints.Medium)
        {
            mods.Medium = Breakpoints.Medium;
        }
        else if (breakpoint is Breakpoints.Large)
        {
            mods.Large = Breakpoints.Large;
        }
        else if (breakpoint is Breakpoints.ExtraLarge)
        {
            mods.ExtraLarge = Breakpoints.ExtraLarge;
        }
        else if (breakpoint is Breakpoints.ExtraLarge2)
        {
            mods.ExtraLarge2 = Breakpoints.ExtraLarge2;
        }

        return mods;
    }

    protected override string Prefix => "m";

    protected override string ToString(Breakpoints? state) => "show";

    public BreakpointMods()
    {
    }
}
