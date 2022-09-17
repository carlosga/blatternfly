namespace Blatternfly.Components;

/// <summary>CircleIcon icon.</summary>
public sealed class CircleIcon : BaseIcon
{
    private static readonly string _svgPath = "M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8z";
    internal static readonly IconDefinition IconDefinition = new(name: "CircleIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
