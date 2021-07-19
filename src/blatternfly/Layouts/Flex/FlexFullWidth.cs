namespace Blatternfly.Layouts
{
    public sealed class FlexFullWidth : FormatBreakpointMods<bool?>
    {
        protected override string Prefix => "m";

        protected override string ToString(bool? value)
        {
            return value.HasValue && value.Value ? "full-width" : null;
        }
    }
}
