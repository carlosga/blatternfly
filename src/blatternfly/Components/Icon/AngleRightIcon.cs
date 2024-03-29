namespace Blatternfly.Components;

/// <summary>AngleRightIcon icon.</summary>
public sealed class AngleRightIcon : BaseIcon
{
    private static readonly string _svgPath = "M224.3 273l-136 136c-9.4 9.4-24.6 9.4-33.9 0l-22.6-22.6c-9.4-9.4-9.4-24.6 0-33.9l96.4-96.4-96.4-96.4c-9.4-9.4-9.4-24.6 0-33.9L54.3 103c9.4-9.4 24.6-9.4 33.9 0l136 136c9.5 9.4 9.5 24.6.1 34z";
    internal static readonly IconDefinition IconDefinition = new(name: "AngleRightIcon", height: 512, width: 256, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
