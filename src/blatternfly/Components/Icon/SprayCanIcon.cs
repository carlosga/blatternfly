namespace Blatternfly.Components;

/// <summary>SprayCanIcon icon.</summary>
public sealed class SprayCanIcon : BaseIcon
{
    private static readonly string _svgPath = "M224 32c0-17.67-14.33-32-32-32h-64c-17.67 0-32 14.33-32 32v96h128V32zm256 96c-17.67 0-32 14.33-32 32s14.33 32 32 32 32-14.33 32-32-14.33-32-32-32zm-256 32H96c-53.02 0-96 42.98-96 96v224c0 17.67 14.33 32 32 32h256c17.67 0 32-14.33 32-32V256c0-53.02-42.98-96-96-96zm-64 256c-44.18 0-80-35.82-80-80s35.82-80 80-80 80 35.82 80 80-35.82 80-80 80zM480 96c17.67 0 32-14.33 32-32s-14.33-32-32-32-32 14.33-32 32 14.33 32 32 32zm-96 32c-17.67 0-32 14.33-32 32s14.33 32 32 32 32-14.33 32-32-14.33-32-32-32zm-96-96c-17.67 0-32 14.33-32 32s14.33 32 32 32 32-14.33 32-32-14.33-32-32-32zm96 0c-17.67 0-32 14.33-32 32s14.33 32 32 32 32-14.33 32-32-14.33-32-32-32zm96 192c-17.67 0-32 14.33-32 32s14.33 32 32 32 32-14.33 32-32-14.33-32-32-32z";
    internal static readonly IconDefinition IconDefinition = new(name: "SprayCanIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
