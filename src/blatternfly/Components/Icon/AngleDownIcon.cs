namespace Blatternfly.Components;

/// <summary>AngleDownIcon icon.</summary>
public sealed class AngleDownIcon : BaseIcon
{
    private static readonly string _svgPath = "M143 352.3L7 216.3c-9.4-9.4-9.4-24.6 0-33.9l22.6-22.6c9.4-9.4 24.6-9.4 33.9 0l96.4 96.4 96.4-96.4c9.4-9.4 24.6-9.4 33.9 0l22.6 22.6c9.4 9.4 9.4 24.6 0 33.9l-136 136c-9.2 9.4-24.4 9.4-33.8 0z";
    internal static readonly IconDefinition IconDefinition = new(name: "AngleDownIcon", height: 512, width: 320, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
