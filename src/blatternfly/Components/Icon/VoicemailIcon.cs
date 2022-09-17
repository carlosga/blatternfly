namespace Blatternfly.Components;

/// <summary>VoicemailIcon icon.</summary>
public sealed class VoicemailIcon : BaseIcon
{
    private static readonly string _svgPath = "M496 128a144 144 0 0 0-119.74 224H263.74A144 144 0 1 0 144 416h352a144 144 0 0 0 0-288zM64 272a80 80 0 1 1 80 80 80 80 0 0 1-80-80zm432 80a80 80 0 1 1 80-80 80 80 0 0 1-80 80z";
    internal static readonly IconDefinition IconDefinition = new(name: "VoicemailIcon", height: 512, width: 640, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
