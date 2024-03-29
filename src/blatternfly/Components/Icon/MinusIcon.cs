namespace Blatternfly.Components;

/// <summary>MinusIcon icon.</summary>
public sealed class MinusIcon : BaseIcon
{
    private static readonly string _svgPath = "M416 208H32c-17.67 0-32 14.33-32 32v32c0 17.67 14.33 32 32 32h384c17.67 0 32-14.33 32-32v-32c0-17.67-14.33-32-32-32z";
    internal static readonly IconDefinition IconDefinition = new(name: "MinusIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
