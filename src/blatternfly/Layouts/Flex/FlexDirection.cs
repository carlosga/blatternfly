namespace Blatternfly.Layouts
{
    public sealed class FlexDirection : FormatBreakpointMods<FlexDirections?>
    {
        protected override string Prefix => "m";

        protected override string ToString(FlexDirections? value)
        {
            return value switch
            {
                FlexDirections.Column        => "column",
                FlexDirections.ColumnReverse => "column-reverse",
                FlexDirections.Row           => "row",
                FlexDirections.RowReverse    => "row-reverse",
                _                            => null
            };
        }        
    }
}
