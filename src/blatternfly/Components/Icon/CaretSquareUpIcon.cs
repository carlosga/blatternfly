namespace Blatternfly.Components;

/// <summary>CaretSquareUpIcon icon.</summary>
public sealed class CaretSquareUpIcon : BaseIcon
{
    private static readonly string _svgPath = "M0 432V80c0-26.51 21.49-48 48-48h352c26.51 0 48 21.49 48 48v352c0 26.51-21.49 48-48 48H48c-26.51 0-48-21.49-48-48zm355.515-140.485l-123.03-123.03c-4.686-4.686-12.284-4.686-16.971 0L92.485 291.515c-7.56 7.56-2.206 20.485 8.485 20.485h246.059c10.691 0 16.045-12.926 8.486-20.485z";
    internal static readonly IconDefinition IconDefinition = new(name: "CaretSquareUpIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
