namespace Blatternfly.Components;

public sealed class SidebarWidthModifiers : FormatBreakpointMods<SidebarWidth?>
{
    protected override string Prefix => "m-width";

    protected override string ToString(SidebarWidth? state)
    {
        return state switch
        {
            SidebarWidth.W25  => "25",
            SidebarWidth.W33  => "33",
            SidebarWidth.W50  => "50",
            SidebarWidth.W66  => "66",
            SidebarWidth.W75  => "75",
            SidebarWidth.W100 => "100",
            _                 => ""
        };
    }
}
