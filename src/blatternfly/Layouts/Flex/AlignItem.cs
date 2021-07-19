using Blatternfly.Components;

namespace Blatternfly.Layouts
{
    public sealed class AlignItem : FormatBreakpointMods<AlignItems?>
    {
        protected override string Prefix => "m-align-items";

        protected override string ToString(AlignItems? value)
        {
            return value switch
            {
                AlignItems.FlexStart => "flex-start",
                AlignItems.FlexEnd   => "flex-end",
                AlignItems.Center    => "center",
                AlignItems.Stretch   => "stretch",
                AlignItems.Baseline  => "baseline",
                _                    => null
            };
        }
    }
}
