namespace Blatternfly.Components;

/// <summary>BookmarkIcon icon.</summary>
public sealed class BookmarkIcon : BaseIcon
{
    private static readonly string _svgPath = "M0 512V48C0 21.49 21.49 0 48 0h288c26.51 0 48 21.49 48 48v464L192 400 0 512z";
    internal static readonly IconDefinition IconDefinition = new(name: "BookmarkIcon", height: 512, width: 384, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
