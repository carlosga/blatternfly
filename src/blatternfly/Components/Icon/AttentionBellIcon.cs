namespace Blatternfly.Components;

/// <summary>AttentionBellIcon icon.</summary>
public sealed class AttentionBellIcon : BaseIcon
{
    private static readonly string _svgPath = "M448,0 C465.333333,0 480.333333,6.33333333 493,19 C505.666667,31.6666667 512,46.6666667 512,64 L512,106 L514.23,106.45 C587.89,121.39 648.48,157.24 696,214 C744,271.333333 768,338.666667 768,416 C768,500 780,568.666667 804,622 C818.666667,652.666667 841.333333,684 872,716 C873.773676,718.829136 875.780658,721.505113 878,724 C890,737.333333 896,752.333333 896,769 C896,785.666667 890,800.333333 878,813 C866,825.666667 850.666667,832 832,832 L63.3,832 C44.9533333,831.84 29.8533333,825.506667 18,813 C6,800.333333 0,785.666667 0,769 C0,752.333333 6,737.333333 18,724 L24,716 L25.06,714.9 C55.1933333,683.28 77.5066667,652.313333 92,622 C116,568.666667 128,500 128,416 C128,338.666667 152,271.333333 200,214 C248,156.666667 309.333333,120.666667 384,106 L384,63.31 C384.166667,46.27 390.5,31.5 403,19 C415.666667,6.33333333 430.666667,0 448,0 Z M576,896 L576,897.08 C575.74,932.6 563.073333,962.573333 538,987 C512.666667,1011.66667 482.666667,1024 448,1024 C413.333333,1024 383.333333,1011.66667 358,987 C332.666667,962.333333 320,932 320,896 L576,896 Z M475,192 L421,192 C400.565464,192 384,208.565464 384,229 L384,539 C384,559.434536 400.565464,576 421,576 L475,576 C495.434536,576 512,559.434536 512,539 L512,229 C512,208.565464 495.434536,192 475,192 Z M448,640 C412.653776,640 384,668.653776 384,704 C384,739.346224 412.653776,768 448,768 C483.346224,768 512,739.346224 512,704 C512,668.653776 483.346224,640 448,640 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "AttentionBellIcon", height: 1024, width: 896, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
