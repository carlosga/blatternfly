namespace Blatternfly.Components;

/// <summary>UsersAltIcon icon.</summary>
public sealed class UsersAltIcon : BaseIcon
{
    private static readonly string _svgPath = "M434.3,665.8 C440.4,661 453.6,651.2 472.9,641 C436,595.6 416,539.3 416,480 C416,473 416.3,466 416.8,459.1 C399.4,452.9 378,448 353.6,448 L221.4,448.3 C154,448 109.7,485.3 109.7,485.3 C27.6,547.5 5.8,692.2 0,768 L0,828 L325.5,828 C350.7,756.5 387.3,702 434.3,665.8 L434.3,665.8 Z M448,224 C448,312.4 376.4,384 288,384 C199.6,384 128,312.4 128,224 C128,135.6 199.7,64 288.1,64 C376.5,64 448,135.6 448,224 L448,224 Z M384,1024 C389.8,948.2 411.6,803.5 493.7,741.3 C493.7,741.3 538,704 605.4,704.3 L737.6,704 C805.1,704 849.3,741.3 849.3,741.3 C849.3,741.3 948,801 960,1024 L384,1024 Z M832,480 C832,568.4 760.4,640 672,640 C583.6,640 512,568.4 512,480 C512,391.6 583.7,320 672.1,320 C760.5,320 832,391.6 832,480 L832,480 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "UsersAltIcon", height: 1024, width: 960, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
