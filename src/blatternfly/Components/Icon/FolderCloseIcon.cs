namespace Blatternfly.Components;

/// <summary>FolderCloseIcon icon.</summary>
public sealed class FolderCloseIcon : BaseIcon
{
    private static readonly string _svgPath = "M1088,256 C1088,256 1088,192 1024,192 L502.3,192 L469.6,130.1 C469.6,130.1 439,64 373.7,64 L64,64 C0,64 0,128 0,128 L0,960 L1088,960 L1088,256 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "FolderCloseIcon", height: 1024, width: 1088, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
