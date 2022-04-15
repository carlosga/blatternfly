namespace Blatternfly;

public abstract class FormatBreakpointMods<T>
{
    private static readonly Breakpoints[] s_BreakpointsOrder =
    {
        Breakpoints.ExtraLarge2,
        Breakpoints.ExtraLarge,
        Breakpoints.Large,
        Breakpoints.Medium,
        Breakpoints.Small,
        Breakpoints.Default
    };

    public T Default { get; set; }
    public T Small { get; set; }
    public T Medium { get; set; }
    public T Large { get; set; }
    public T ExtraLarge { get; set; }
    public T ExtraLarge2 { get; set; }

    private bool IsEmpty
    {
        get => Default is null
            && Small is null
            && Medium is null
            && Large is null
            && ExtraLarge is null
            && ExtraLarge2 is null;
    }

    internal string CssClass(Breakpoints? breakpoint = null)
    {
        if (IsEmpty)
        {
            return null;
        }

        if (breakpoint.HasValue)
        {
            var isBreakpointInMods = IsBreakpointInMods(breakpoint.Value);

            if (isBreakpointInMods)
            {
                return CssClass(breakpoint.Value);
            }

            // the current breakpoint is not specified in mods, so we try to find the next nearest
            var breakpointsIndex =
                breakpoint.HasValue
                    ? Array.IndexOf(s_BreakpointsOrder, breakpoint.Value)
                        : -1;

            for (var i = breakpointsIndex; i < s_BreakpointsOrder.Length; i++)
            {
                if (IsBreakpointInMods(s_BreakpointsOrder[i]))
                {
                    return CssClass(s_BreakpointsOrder[i]);
                }
            }
            return null;
        }

        return new CssBuilder()
            .AddClass(() => $"pf-{Prefix}-{ToString(Default)}"           , Default     is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(Small)}-on-sm"       , Small       is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(Medium)}-on-md"      , Medium      is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(Large)}-on-lg"       , Large       is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge)}-on-xl"  , ExtraLarge  is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge2)}-on-2xl", ExtraLarge2 is not null)
            .Build();
    }

    protected string CssClass(Breakpoints breakpoint)
    {
        return new CssBuilder()
            .AddClass(() => $"pf-{Prefix}-{ToString(Default)}"    , breakpoint == Breakpoints.Default)
            .AddClass(() => $"pf-{Prefix}-{ToString(Small)}"      , breakpoint == Breakpoints.Small)
            .AddClass(() => $"pf-{Prefix}-{ToString(Medium)}"     , breakpoint == Breakpoints.Medium)
            .AddClass(() => $"pf-{Prefix}-{ToString(Large)}"      , breakpoint == Breakpoints.Large)
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge)}" , breakpoint == Breakpoints.ExtraLarge)
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge2)}", breakpoint == Breakpoints.ExtraLarge2)
            .Build();
    }

    protected abstract string Prefix { get; }

    protected abstract string ToString(T value);

    private bool IsBreakpointInMods(Breakpoints breakpoint)
    {
        return Default     is not null && breakpoint == Breakpoints.Default
            || Small       is not null && breakpoint == Breakpoints.Small
            || Medium      is not null && breakpoint == Breakpoints.Medium
            || Large       is not null && breakpoint == Breakpoints.Large
            || ExtraLarge  is not null && breakpoint == Breakpoints.ExtraLarge
            || ExtraLarge2 is not null && breakpoint == Breakpoints.ExtraLarge2;
    }
}
