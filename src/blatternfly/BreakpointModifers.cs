namespace Blatternfly;

/// Breakpoint modifiers.
public sealed class BreakpointModifers : FormatBreakpointMods<Breakpoint?>
{
    internal static BreakpointModifers FromBreakpoint(Breakpoint breakpoint)
    {
        var mods = new BreakpointModifers();

        if (breakpoint is Breakpoint.Default)
        {
            mods.Default = Breakpoint.Default;
        }
        else if (breakpoint is Breakpoint.Small)
        {
            mods.Small = Breakpoint.Small;
        }
        else if (breakpoint is Breakpoint.Medium)
        {
            mods.Medium = Breakpoint.Medium;
        }
        else if (breakpoint is Breakpoint.Large)
        {
            mods.Large = Breakpoint.Large;
        }
        else if (breakpoint is Breakpoint.ExtraLarge)
        {
            mods.ExtraLarge = Breakpoint.ExtraLarge;
        }
        else if (breakpoint is Breakpoint.ExtraLarge2)
        {
            mods.ExtraLarge2 = Breakpoint.ExtraLarge2;
        }

        return mods;
    }

    protected override string Prefix => "m";

    protected override string ToString(Breakpoint? state) => "show";
}
