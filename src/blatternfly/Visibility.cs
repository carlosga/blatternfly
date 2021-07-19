namespace Blatternfly
{
    public sealed class Visibility : FormatBreakpointMods<Visibilities?>
    {
        protected override string Prefix => "u";
        
        protected override string ToString(Visibilities? state)
        {
            return state == Visibilities.Hidden ? "hidden" : "visible";
        }
    }
}
