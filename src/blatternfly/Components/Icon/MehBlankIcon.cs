namespace Blatternfly.Components;

/// <summary>MehBlankIcon icon.</summary>
public sealed class MehBlankIcon : BaseIcon
{
    private static readonly string _svgPath = "M248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zm-80 232c-17.7 0-32-14.3-32-32s14.3-32 32-32 32 14.3 32 32-14.3 32-32 32zm160 0c-17.7 0-32-14.3-32-32s14.3-32 32-32 32 14.3 32 32-14.3 32-32 32z";
    internal static readonly IconDefinition IconDefinition = new(name: "MehBlankIcon", height: 512, width: 496, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
