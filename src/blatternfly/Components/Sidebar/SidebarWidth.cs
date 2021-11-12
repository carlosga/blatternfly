using System.Text;

namespace Blatternfly.Components;

public sealed class SidebarWidth
{
    private static string StateValue(SidebarWidths state)
    {
        return state switch
        {
            SidebarWidths.W25  => "25",
            SidebarWidths.W33  => "33",
            SidebarWidths.W50  => "50",
            SidebarWidths.W66  => "66",
            SidebarWidths.W75  => "75",
            SidebarWidths.W100 => "100",
            _                  => ""
        };
    }

    public SidebarWidths? Default { get; set; }
    public SidebarWidths? Small { get; set; }
    public SidebarWidths? Medium { get; set; }
    public SidebarWidths? Large { get; set; }
    public SidebarWidths? ExtraLarge { get; set; }
    public SidebarWidths? ExtraLarge2 { get; set; }

    private bool IsEmpty
    {
        get => !Default.HasValue
            && !Small.HasValue
            && !Medium.HasValue
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
            if (Small.HasValue)
            {
                builder.AppendFormat("pf-m-width-{0}-on-sm ", StateValue(Small.Value));
            }
            if (Medium.HasValue)
            {
                builder.AppendFormat("pf-m-width-{0}-on-md ", StateValue(Medium.Value));
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
