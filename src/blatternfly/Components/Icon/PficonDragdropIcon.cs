namespace Blatternfly.Components;

/// <summary>PficonDragdropIcon icon.</summary>
public sealed class PficonDragdropIcon : BaseIcon
{
    private static readonly string _svgPath = "M202.207319,695.707319 C222.907319,714.307319 256.007319,699.707319 256.007319,671.907319 L256.007319,352.107319 C256.007319,324.307319 222.807319,309.707319 202.107319,328.407319 L11.5073185,488.107319 C4.00731852,494.307319 0.207318525,503.107319 0.00731852476,512.007319 C-0.192681475,521.307319 3.70731852,530.607319 11.6073185,537.107319 L202.207319,695.707319 Z M1012.40732,537.207319 C1020.10732,530.807319 1024.00732,521.707319 1024.00732,512.707319 C1024.00732,503.607319 1020.20732,494.607319 1012.50732,488.207319 L821.907319,328.407319 C801.207319,309.707319 768.007319,324.307319 768.007319,352.107319 L768.007319,671.907319 C768.007319,699.607319 801.107319,714.307319 821.807319,695.707319 L1012.40732,537.207319 Z M328.307319,202.207319 C309.707319,222.907319 324.307319,256.007319 352.107319,256.007319 L671.907319,256.007319 C699.707319,256.007319 714.307319,222.807319 695.607319,202.107319 L535.907319,11.5073185 C529.707319,4.00731852 520.907319,0.207318525 512.007319,0.00731852475 C502.707319,-0.192681475 493.407319,3.70731852 486.907319,11.6073185 L328.307319,202.207319 Z M486.807319,1012.40732 C493.207319,1020.10732 502.307319,1024.00732 511.307319,1024.00732 C520.407319,1024.00732 529.407319,1020.20732 535.807319,1012.50732 L695.507319,821.907319 C714.207319,801.207319 699.607319,768.007319 671.807319,768.007319 L352.107319,768.007319 C324.407319,768.007319 309.707319,801.107319 328.307319,821.807319 L486.807319,1012.40732 Z M480.007319,400.007319 C480.007319,444.107319 444.107319,480.007319 400.007319,480.007319 C355.907319,480.007319 320.007319,444.107319 320.007319,400.007319 C320.007319,355.907319 355.907319,320.007319 400.007319,320.007319 C444.107319,320.007319 480.007319,355.907319 480.007319,400.007319 L480.007319,400.007319 Z M704.007319,624.007319 C704.007319,668.107319 668.107319,704.007319 624.007319,704.007319 C579.907319,704.007319 544.007319,668.107319 544.007319,624.007319 C544.007319,579.907319 579.907319,544.007319 624.007319,544.007319 C668.307319,544.107319 704.007319,579.907319 704.007319,624.007319 L704.007319,624.007319 Z M704.007319,400.007319 C704.007319,444.107319 668.107319,480.007319 624.007319,480.007319 C579.907319,480.007319 544.007319,444.107319 544.007319,400.007319 C544.007319,355.907319 579.907319,320.007319 624.007319,320.007319 C668.107319,320.007319 704.007319,355.907319 704.007319,400.007319 L704.007319,400.007319 Z M480.007319,624.007319 C480.007319,668.107319 444.107319,704.007319 400.007319,704.007319 C355.907319,704.007319 320.007319,668.107319 320.007319,624.007319 C320.007319,579.907319 355.907319,544.007319 400.007319,544.007319 C444.107319,544.007319 480.007319,579.707319 480.007319,624.007319 L480.007319,624.007319 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "PficonDragdropIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
