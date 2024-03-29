namespace Blatternfly.Components;

/// <summary>EthereumIcon icon.</summary>
public sealed class EthereumIcon : BaseIcon
{
    private static readonly string _svgPath = "M311.9 260.8L160 353.6 8 260.8 160 0l151.9 260.8zM160 383.4L8 290.6 160 512l152-221.4-152 92.8z";
    internal static readonly IconDefinition IconDefinition = new(name: "EthereumIcon", height: 512, width: 320, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
