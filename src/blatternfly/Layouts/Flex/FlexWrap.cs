namespace Blatternfly.Layouts
{
    public sealed class FlexWrap : FormatBreakpointMods<FlexWraps?>
    {
        protected override string Prefix => "m";

        protected override string ToString(FlexWraps? value)
        {
            return value switch
            {
                FlexWraps.Wrap        => "wrap",
                FlexWraps.WrapReverse => "wrap-reverse",
                FlexWraps.Nowrap      => "nowrap",
                _                     => null
            };
        }
    }
}
