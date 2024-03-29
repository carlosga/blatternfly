namespace Blatternfly.Components;

/// <summary>PrintAltIcon icon.</summary>
public sealed class PrintAltIcon : BaseIcon
{
    private static readonly string _svgPath = "M960,256 L64,256 C28.8,256 0,284.8 0,320 L0,640 C0,675.2 28.7,704 63.9,704 L192,704 L192,960 L832,960 L832,704 L960,704 C995.2,704 1024,675.2 1024,640 L1024,320 C1024,284.8 995.2,256 960,256 Z M768,886.9 L256,886.9 L256,576 L768,576 L768,886.9 Z M896,432 C869.5,432 848,410.5 848,384 C848,357.5 869.5,336 896,336 C922.6,336 944,357.5 944,384 C944,410.5 922.5,432 896,432 Z M192,192 L832,192 L832,64 L192,64 L192,192 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "PrintAltIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
