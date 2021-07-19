namespace Blatternfly
{
    public sealed class Padding : FormatBreakpointMods<Paddings?>
    {
        protected override string Prefix => "m";

        protected override string ToString(Paddings? state)
        {
            return state == Paddings.Padding ? "padding" : "no-padding";
        }
    }
}
