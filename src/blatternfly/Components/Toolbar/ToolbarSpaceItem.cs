using System.Text;

namespace Blatternfly.Components
{
    public sealed class ToolbarSpaceItem : FormatBreakpointMods<ToolbarSpaceItems?>
    {
        protected override string Prefix => "m-space-items";

        protected override string ToString(ToolbarSpaceItems? state)
        {
            return state switch
            {
                ToolbarSpaceItems.None        => "none",
                ToolbarSpaceItems.Small       => "sm",
                ToolbarSpaceItems.Medium      => "md",
                ToolbarSpaceItems.Large       => "lg",
                ToolbarSpaceItems.ExtraLarge  => "xl",
                ToolbarSpaceItems.ExtraLarge2 => "2xl",
                _                             => null
            };
        }
    }
}
