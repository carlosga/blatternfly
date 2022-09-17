namespace Blatternfly.Components;

/// <summary>RegionsIcon icon.</summary>
public sealed class RegionsIcon : BaseIcon
{
    private static readonly string _svgPath = "M576,864 C274.3,864.2 175.7,806 143.6,768 C128.1,749.6 128,768 128,768 L128,896 C128,966.7 328.5,1024 576,1024 C823.5,1024 1024,966.7 1024,896 L1024,768 C1024,768 1024,749.6 1008.4,768 C976.2,805.9 877.7,863.8 576,864 L576,864 Z M576,640 C274.3,640 175.7,581.9 143.6,544 C128,525.6 128,544 128,544 L128,640 C128,710.7 328.5,768 576,768 C823.5,768 1024,710.7 1024,640 L1024,544 C1024,544 1024,525.6 1008.4,544 C976.3,581.9 877.7,640 576,640 L576,640 Z M576,416 C274.3,416 175.7,357.9 143.6,320 C128,301.6 128,320 128,320 L128,416 C128,486.7 328.5,544 576,544 C823.5,544 1024,486.7 1024,416 L1024,320 C1024,320 1024,301.6 1008.4,320 C976.3,357.9 877.7,416 576,416 L576,416 Z M1024,192 C1024,262.7 823.5,320 576,320 C328.5,320 128,262.7 128,192 L128,128 C128,57.3 328.5,0 576,0 C823.5,0 1024,57.3 1024,128 L1024,192 Z M1088,144 L1088,880 C1088,888.8 1095.2,896 1104,896 L1136,896 C1144.8,896 1152,888.8 1152,880 L1152,144 C1152,135.2 1144.8,128 1136,128 L1104,128 C1095.2,128 1088,135.2 1088,144 L1088,144 Z M0,144 L0,880 C0,888.8 7.2,896 16,896 L48,896 C56.8,896 64,888.8 64,880 L64,144 C64,135.2 56.8,128 48,128 L16,128 C7.2,128 0,135.2 0,144 L0,144 Z";
    internal static readonly IconDefinition IconDefinition = new(name: "RegionsIcon", height: 1024, width: 1152, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
