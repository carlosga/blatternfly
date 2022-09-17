namespace Blatternfly.Components;

/// <summary>OnRunningIcon icon.</summary>
public sealed class OnRunningIcon : BaseIcon
{
    private static readonly string _svgPath = "M512.1,895.9 C300.3,895.9 128.1,723.8 128.1,511.9 C128.1,300.2 300.3,127.9 512.1,127.9 C723.9,127.9 896,300.2 896.100043,511.9 C896.2,723.6 723.8,895.9 512.1,895.9 M512.1,0 C229.7,0 0,229.7 0,512 C0,794.3 229.7,1024 512.1,1024 C794.3,1024 1024,794.3 1024,512 C1024,229.7 794.3,0 512.1,0 M716.3,482.9 C710,495.2 575.5,679.5 493.7,782.4 C478,800.2 463.4,794.2 457.3,790.3 C443.9,781.4 443.1,771.7 451,745 C458.9,718.3 494.1,576 494.1,576 L341.3,576 C328.2,576.2 312.2,576.2 307.1,563.8 C302.2,552 306.9,541.2 314.4,530.8 C370,453.5 508.1,264.9 508.1,264.9 C508.1,264.9 527.2,239.7 541.4,238.3 C554.4,237 562.9,240.5 567,249.6 C572.1,260.2 570.4,272.9 566.8,286.9 C563.5,300 526.4,448 526.4,448 L695.3,448 C702.6,448 711.5,449.4 717.4,457 C723.3,464.6 719.5,477 716.3,482.9";
    internal static readonly IconDefinition IconDefinition = new(name: "OnRunningIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
