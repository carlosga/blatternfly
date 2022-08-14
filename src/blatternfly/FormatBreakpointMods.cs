namespace Blatternfly;

public abstract class FormatBreakpointMods<T>
{
    private static readonly Breakpoint[] s_BreakpointsOrder =
    {
        Breakpoint.ExtraLarge2,
        Breakpoint.ExtraLarge,
        Breakpoint.Large,
        Breakpoint.Medium,
        Breakpoint.Small,
        Breakpoint.Default
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

    internal string CssClass(Breakpoint? breakpoint = null)
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
            .AddClass(() => $"pf-{Prefix}-{ToString(Default)}"                   , Default     is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(Small)}-on-sm{Suffix}"       , Small       is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(Medium)}-on-md{Suffix}"      , Medium      is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(Large)}-on-lg{Suffix}"       , Large       is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge)}-on-xl{Suffix}"  , ExtraLarge  is not null)
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge2)}-on-2xl{Suffix}", ExtraLarge2 is not null)
            .Build();
    }

    protected string CssClass(Breakpoint breakpoint)
    {
        return new CssBuilder()
            .AddClass(() => $"pf-{Prefix}-{ToString(Default)}"            , breakpoint is Breakpoint.Default)
            .AddClass(() => $"pf-{Prefix}-{ToString(Small)}{Suffix}"      , breakpoint is Breakpoint.Small)
            .AddClass(() => $"pf-{Prefix}-{ToString(Medium)}{Suffix}"     , breakpoint is Breakpoint.Medium)
            .AddClass(() => $"pf-{Prefix}-{ToString(Large)}{Suffix}"      , breakpoint is Breakpoint.Large)
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge)}{Suffix}" , breakpoint is Breakpoint.ExtraLarge)
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge2)}{Suffix}", breakpoint is Breakpoint.ExtraLarge2)
            .Build();
    }

    protected abstract string Prefix { get; }
    protected virtual string Suffix { get; } = string.Empty;

    protected abstract string ToString(T value);

    private bool IsBreakpointInMods(Breakpoint breakpoint)
    {
        return Default     is not null && breakpoint is Breakpoint.Default
            || Small       is not null && breakpoint is Breakpoint.Small
            || Medium      is not null && breakpoint is Breakpoint.Medium
            || Large       is not null && breakpoint is Breakpoint.Large
            || ExtraLarge  is not null && breakpoint is Breakpoint.ExtraLarge
            || ExtraLarge2 is not null && breakpoint is Breakpoint.ExtraLarge2;
    }
}
