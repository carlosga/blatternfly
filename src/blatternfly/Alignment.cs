namespace Blatternfly
{
    public sealed class Alignment : FormatBreakpointMods<Alignments?>
    {
        protected override string Prefix => "m-align";

        protected override string ToString(Alignments? state)
        {
            return state == Alignments.Left ? "left" : "right";
        }
    }
}
