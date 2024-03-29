namespace Blatternfly.Components;

/// <summary>BlackTieIcon icon.</summary>
public sealed class BlackTieIcon : BaseIcon
{
    private static readonly string _svgPath = "M0 32v448h448V32H0zm316.5 325.2L224 445.9l-92.5-88.7 64.5-184-64.5-86.6h184.9L252 173.2l64.5 184z";
    internal static readonly IconDefinition IconDefinition = new(name: "BlackTieIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
