namespace Blatternfly.Components;

/// <summary>MinusSquareIcon icon.</summary>
public sealed class MinusSquareIcon : BaseIcon
{
    private static readonly string _svgPath = "M400 32H48C21.5 32 0 53.5 0 80v352c0 26.5 21.5 48 48 48h352c26.5 0 48-21.5 48-48V80c0-26.5-21.5-48-48-48zM92 296c-6.6 0-12-5.4-12-12v-56c0-6.6 5.4-12 12-12h264c6.6 0 12 5.4 12 12v56c0 6.6-5.4 12-12 12H92z";
    internal static readonly IconDefinition IconDefinition = new(name: "MinusSquareIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
