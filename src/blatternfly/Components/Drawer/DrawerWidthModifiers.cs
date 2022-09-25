namespace Blatternfly.Components;

/// <summary>Drawer widths modifiers.</summary>
public sealed class DrawerWidthModifiers
{
    private static string ToString(DrawerWidth state)
    {
        return state switch
        {
            DrawerWidth.W25  => "25",
            DrawerWidth.W33  => "33",
            DrawerWidth.W50  => "50",
            DrawerWidth.W66  => "66",
            DrawerWidth.W75  => "75",
            DrawerWidth.W100 => "100",
            _                => ""
        };
    }

    public DrawerWidth? Default { get; set; }
    public DrawerWidth? Large { get; set; }
    public DrawerWidth? ExtraLarge { get; set; }
    public DrawerWidth? ExtraLarge2 { get; set; }

    private bool IsEmpty
    {
        get => !Default.HasValue
            && !Large.HasValue
            && !ExtraLarge.HasValue
            && !ExtraLarge2.HasValue;
    }

    internal string WidthClass
    {
        get
        {
            if (IsEmpty)
            {
                return null;
            }

            return new CssBuilder()
                .AddClass(() => $"pf-m-width-{ToString(Default.Value)}"           , Default.HasValue)
                .AddClass(() => $"pf-m-width-{ToString(Large.Value)}-on-lg"       , Large.HasValue)
                .AddClass(() => $"pf-m-width-{ToString(ExtraLarge.Value)}-on-xl"  , ExtraLarge.HasValue)
                .AddClass(() => $"pf-m-width-{ToString(ExtraLarge2.Value)}-on-2xl", ExtraLarge2.HasValue)
                .Build();
        }
    }
}
