namespace Blatternfly.Components;

/// <summary>ViacoinIcon icon.</summary>
public sealed class ViacoinIcon : BaseIcon
{
    private static readonly string _svgPath = "M384 32h-64l-80.7 192h-94.5L64 32H0l48 112H0v48h68.5l13.8 32H0v48h102.8L192 480l89.2-208H384v-48h-82.3l13.8-32H384v-48h-48l48-112zM192 336l-27-64h54l-27 64z";
    internal static readonly IconDefinition IconDefinition = new(name: "ViacoinIcon", height: 512, width: 384, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
