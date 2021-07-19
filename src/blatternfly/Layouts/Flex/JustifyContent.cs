namespace Blatternfly.Layouts
{
    public sealed class JustifyContent : FormatBreakpointMods<JustifyContents?>
    {
        protected override string Prefix => "m-justify-content";

        protected override string ToString(JustifyContents? value)
        {
            return value switch
            {
                JustifyContents.FlexStart    => "flex-start",
                JustifyContents.FlexEnd      => "flex-end",
                JustifyContents.Center       => "center",
                JustifyContents.SpaceBetween => "space-between",
                JustifyContents.SpaceAround  => "space-around",
                JustifyContents.SpaceEvenly  => "space-evenly",
                _                            => null
            };
        }
    }
}
