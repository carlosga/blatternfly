namespace Blatternfly.Components;

public sealed class CatalogIcon : BaseIcon
{
    private static readonly string _svgPath = "M576,160 C687.3,88.6 874.6,32 960,32 L960,800 C898.8,783.1 738,760.5 576,864 L576,160 Z M1024,96 C1088,96 1088,162.8 1088,162.8 L1088,928 C1088,992 985.7,989.9 985.7,989.9 C863.1,804.7 576,992 576,992 L576,925.4 C863,728.7 1024,928 1024,928 L1024,96 Z M128,800 L128,32 C212.9,32 400.6,88.3 512,160 L512,864 C352,760.5 189.3,783.2 128,800 Z M512,925.4 L512,992 C512,992 227.9,805.8 102.5,989.9 C102.5,989.9 0,992 0,928 L0,162.8 C0,162.8 0,96 64,96 L64,928 C64,927.9 226,728.7 512,925.4 Z";
    public static readonly IconDefinition IconDefinition = new(name: "CatalogIcon", height: 1024, width: 1088, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
