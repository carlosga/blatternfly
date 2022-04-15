using System.Text;

namespace Blatternfly.Components;

public sealed class DrawerWidthModifiers
{
    private static string StateValue(DrawerWidth state)
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

            var builder = new StringBuilder();

            if (Default.HasValue)
            {
                builder.AppendFormat("pf-m-width-{0} ", StateValue(Default.Value));
            }
            if (Large.HasValue)
            {
                builder.AppendFormat("pf-m-width-{0}-on-lg ", StateValue(Large.Value));
            }
            if (ExtraLarge.HasValue)
            {
                builder.AppendFormat("pf-m-width-{0}-on-xl ", StateValue(ExtraLarge.Value));
            }
            if (ExtraLarge2.HasValue)
            {
                builder.AppendFormat("pf-m-width-{0}-on-2xl", StateValue(ExtraLarge2.Value));
            }
            return builder.ToString();
        }
    }
}
