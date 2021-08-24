namespace Blatternfly
{
    public sealed class MastheadDisplay : FormatBreakpointMods<MastheadDisplayType?>
    {
        protected override string Prefix => "m-display";

        protected override string ToString(MastheadDisplayType? state)
        {
            return state == MastheadDisplayType.Inline ? "inline" : "stack";
        }
    }
}
