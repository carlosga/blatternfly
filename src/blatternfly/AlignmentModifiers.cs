namespace Blatternfly;

/// <summary>Alignment modifiers.</summary>
public sealed class AlignmentModifiers : FormatBreakpointMods<Alignment?>
{
    protected override string Prefix => "m-align";

    protected override string ToString(Alignment? state)
    {
        return state is Alignment.Left ? "left" : "right";
    }
}
