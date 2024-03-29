﻿namespace Blatternfly.Layouts;

/// <summary>Flex wrap modifiers.</summary>
public sealed class FlexWrapModifiers : FormatBreakpointMods<FlexWrap?>
{
    protected override string Prefix => "m";

    protected override string ToString(FlexWrap? value)
    {
        return value switch
        {
            FlexWrap.Wrap        => "wrap",
            FlexWrap.WrapReverse => "wrap-reverse",
            FlexWrap.Nowrap      => "nowrap",
            _                    => null
        };
    }
}
