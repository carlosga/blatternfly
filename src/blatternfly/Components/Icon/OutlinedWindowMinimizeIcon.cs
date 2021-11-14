namespace Blatternfly.Components;

public sealed class OutlinedWindowMinimizeIcon : BaseIcon
{
    private static readonly string _svgPath = "M480 480H32c-17.7 0-32-14.3-32-32s14.3-32 32-32h448c17.7 0 32 14.3 32 32s-14.3 32-32 32z";
    public static readonly IconDefinition IconDefinition = new(name: "OutlinedWindowMinimizeIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
