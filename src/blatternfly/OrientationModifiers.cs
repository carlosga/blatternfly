namespace Blatternfly;

/// <summary>Orientation modifiers.</summary>
public sealed class OrientationModifiers : FormatBreakpointMods<Orientation?>
{
    protected override string Prefix => "m";

    protected override string ToString(Orientation? state) => state is Orientation.Vertical ? "vertical" : "horizontal";
}
