namespace Blatternfly;

public abstract class FormatBreakpointMods<T>
{
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

        return new CssBuilder()
            .AddClass(() => $"pf-{Prefix}-{ToString(Default)}"           , Default     is not null && (breakpoint is null || breakpoint.Value == Breakpoints.Default))
            .AddClass(() => $"pf-{Prefix}-{ToString(Small)}-on-sm"       , Small       is not null && (breakpoint is null || breakpoint.Value == Breakpoints.Small))
            .AddClass(() => $"pf-{Prefix}-{ToString(Medium)}-on-md"      , Medium      is not null && (breakpoint is null || breakpoint.Value == Breakpoints.Medium))
            .AddClass(() => $"pf-{Prefix}-{ToString(Large)}-on-lg"       , Large       is not null && (breakpoint is null || breakpoint.Value == Breakpoints.Large))
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge)}-on-xl"  , ExtraLarge  is not null && (breakpoint is null || breakpoint.Value == Breakpoints.ExtraLarge))
            .AddClass(() => $"pf-{Prefix}-{ToString(ExtraLarge2)}-on-2xl", ExtraLarge2 is not null && (breakpoint is null || breakpoint.Value == Breakpoints.ExtraLarge2))
            .Build();
    }

    protected abstract string Prefix { get; }

    protected abstract string ToString(T value);
}
