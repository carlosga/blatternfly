namespace Blatternfly.Components;

/// <summary>SortIcon icon.</summary>
public sealed class SortIcon : BaseIcon
{
    private static readonly string _svgPath = "M41 288h238c21.4 0 32.1 25.9 17 41L177 448c-9.4 9.4-24.6 9.4-33.9 0L24 329c-15.1-15.1-4.4-41 17-41zm255-105L177 64c-9.4-9.4-24.6-9.4-33.9 0L24 183c-15.1 15.1-4.4 41 17 41h238c21.4 0 32.1-25.9 17-41z";
    internal static readonly IconDefinition IconDefinition = new(name: "SortIcon", height: 512, width: 320, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
