namespace Blatternfly.Components;

public sealed class BandcampIcon : BaseIcon
{
    private static readonly string _svgPath = "M256,8C119,8,8,119,8,256S119,504,256,504,504,393,504,256,393,8,256,8Zm48.2,326.1h-181L207.9,178h181Z";
    public static readonly IconDefinition IconDefinition = new(name: "BandcampIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
