using System.Text;

namespace Blatternfly;

public abstract class FormatBreakpointStyles<T>
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

    protected abstract string BaseStyle { get; }

    internal string CssStyle
    {
        get
        {
            if (IsEmpty)
            {
                return null;
            }

            var cssStyle = new StyleBuilder()
                .AddStyle($"--{BaseStyle}"       , Default    , Default is not null)
                .AddStyle($"--{BaseStyle}-on-sm" , Small      , Small is not null)
                .AddStyle($"--{BaseStyle}-on-md" , Medium     , Medium is not null)
                .AddStyle($"--{BaseStyle}-on-lg" , Large      , Large is not null)
                .AddStyle($"--{BaseStyle}-on-xl" , ExtraLarge , ExtraLarge is not null)
                .AddStyle($"--{BaseStyle}-on-2xl", ExtraLarge2, ExtraLarge2 is not null)
                .Build();

            return cssStyle;
        }
    }
}
