namespace Blatternfly.Components;

/// <summary>IceCreamIcon icon.</summary>
public sealed class IceCreamIcon : BaseIcon
{
    private static readonly string _svgPath = "M368 160h-.94a144 144 0 1 0-286.12 0H80a48 48 0 0 0 0 96h288a48 48 0 0 0 0-96zM195.38 493.69a31.52 31.52 0 0 0 57.24 0L352 288H96z";
    internal static readonly IconDefinition IconDefinition = new(name: "IceCreamIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
