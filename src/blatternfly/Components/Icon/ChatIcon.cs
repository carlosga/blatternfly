namespace Blatternfly.Components;

public sealed class ChatIcon : BaseIcon
{
    private static readonly string _svgPath = "M383.8,575.6 C380,761 256,768 256,768 L256,575.9 L128,575.9 L128,192 L768,192 L768,575.9 L383.8,575.6 Z M896,384 L896,123.9 C894.4,76.9 879.7,64 845.2,64 L64,64 C7.7,64 0,69.3 0,123.9 L0,634.6 C0,705.7 0,702.5 64.7,704 L128,704 L128,860.7 C128,884.5 141.6,896 158.8,896 C298.9,896 400.2,894.8 480,704 L511.9,704 L511.9,768 C512.2,832.7 512,832.2 573.8,832 L768,832 C782,906 833,960 895.9,960 L944,960 C952.836556,960 960,952.836556 960,944 L960,832 C1019.3,832.1 1023.5,832.7 1024,768.1 L1024,451.4 C1024,392.9 1023.9,384.5 964.2,384 L896,384 Z";
    public static readonly IconDefinition IconDefinition = new(name: "ChatIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
