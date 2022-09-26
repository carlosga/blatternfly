namespace Blatternfly.Layouts;

/// <summary>Justify content modifiers.</summary>
public sealed class JustifyContentModifiers : FormatBreakpointMods<JustifyContent?>
{
    protected override string Prefix => "m-justify-content";

    protected override string ToString(JustifyContent? value)
    {
        return value switch
        {
            JustifyContent.FlexStart    => "flex-start",
            JustifyContent.FlexEnd      => "flex-end",
            JustifyContent.Center       => "center",
            JustifyContent.SpaceBetween => "space-between",
            JustifyContent.SpaceAround  => "space-around",
            JustifyContent.SpaceEvenly  => "space-evenly",
            _                           => null
        };
    }
}
