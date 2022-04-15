namespace Blatternfly;

public sealed class VisibilityModifiers : FormatBreakpointMods<Visibility?>
{
    protected override string Prefix => "m";

    protected override string ToString(Visibility? state)
        => state is Visibility.Hidden ? "hidden" : "visible";
}
