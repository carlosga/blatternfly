namespace Blatternfly.Components;

/// <summary>FlushedIcon icon.</summary>
public sealed class FlushedIcon : BaseIcon
{
    private static readonly string _svgPath = "M344 200c-13.3 0-24 10.7-24 24s10.7 24 24 24 24-10.7 24-24-10.7-24-24-24zm-192 0c-13.3 0-24 10.7-24 24s10.7 24 24 24 24-10.7 24-24-10.7-24-24-24zM248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zM80 224c0-39.8 32.2-72 72-72s72 32.2 72 72-32.2 72-72 72-72-32.2-72-72zm232 176H184c-21.2 0-21.2-32 0-32h128c21.2 0 21.2 32 0 32zm32-104c-39.8 0-72-32.2-72-72s32.2-72 72-72 72 32.2 72 72-32.2 72-72 72z";
    internal static readonly IconDefinition IconDefinition = new(name: "FlushedIcon", height: 512, width: 496, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
