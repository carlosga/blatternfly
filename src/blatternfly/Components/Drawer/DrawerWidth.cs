using System.Text;

namespace Blatternfly.Components;

public sealed class DrawerWidth
{
    private static string StateValue(DrawerWidths state)
    {
        return state switch
        {
            DrawerWidths.W25  => "25",
            DrawerWidths.W33  => "33",
            DrawerWidths.W50  => "50",
            DrawerWidths.W66  => "66",
            DrawerWidths.W75  => "75",
            DrawerWidths.W100 => "100",
            _                 => ""
        };
    }

    public DrawerWidths? Default { get; set; }
    public DrawerWidths? Large { get; set; }
    public DrawerWidths? ExtraLarge { get; set; }
    public DrawerWidths? ExtraLarge2 { get; set; }

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
