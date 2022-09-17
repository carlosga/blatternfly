namespace Blatternfly.Components;

/// <summary>VuejsIcon icon.</summary>
public sealed class VuejsIcon : BaseIcon
{
    private static readonly string _svgPath = "M356.9 64.3H280l-56 88.6-48-88.6H0L224 448 448 64.3h-91.1zm-301.2 32h53.8L224 294.5 338.4 96.3h53.8L224 384.5 55.7 96.3z";
    internal static readonly IconDefinition IconDefinition = new(name: "VuejsIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
