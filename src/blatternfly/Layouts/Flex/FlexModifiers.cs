namespace Blatternfly.Layouts;

public sealed class FlexModifiers : FormatBreakpointMods<FlexState?>
{
    protected override string Prefix => "m";

    protected override string ToString(FlexState? value)
    {
        return value switch
        {
            FlexState.Default => "flex-default",
            FlexState.None    => "flex-none",
            FlexState.Flex1   => "flex-1",
            FlexState.Flex2   => "flex-2",
            FlexState.Flex3   => "flex-3",
            FlexState.Flex4   => "flex-4",
            _                 => null
        };
    }
}
