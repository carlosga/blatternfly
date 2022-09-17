namespace Blatternfly.Components;

/// <summary>DumpsterFireIcon icon.</summary>
public sealed class DumpsterFireIcon : BaseIcon
{
    private static readonly string _svgPath = "M418.7 104.1l.2-.2-14.4-72H304v128h60.8c16.2-19.3 34.2-38.2 53.9-55.8zM272 32H171.5l-25.6 128H272V32zm189.3 72.1c18.2 16.3 35.5 33.7 51.1 51.5 5.7-5.6 11.4-11.1 17.3-16.3l21.3-19 21.3 19c1.1.9 2.1 2.1 3.1 3.1-.1-.8.2-1.5 0-2.3l-24-96C549.7 37 543.3 32 536 32h-98.9l12.3 61.5 11.9 10.6zM16 160h97.3l25.6-128H40c-7.3 0-13.7 5-15.5 12.1l-24 96C-2 150.2 5.6 160 16 160zm324.6 32H32l4 32H16c-8.8 0-16 7.2-16 16v32c0 8.8 7.2 16 16 16h28l20 160v16c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16v-16h208.8c-30.2-33.7-48.8-77.9-48.8-126.4 0-35.9 19.9-82.9 52.6-129.6zm210.5-28.8c-14.9 13.3-28.3 27.2-40.2 41.2-19.5-25.8-43.6-52-71-76.4-70.2 62.7-120 144.3-120 193.6 0 87.5 71.6 158.4 160 158.4s160-70.9 160-158.4c.1-36.6-37-112.2-88.8-158.4zm-18.6 229.4c-14.7 10.7-32.9 17-52.5 17-49 0-88.9-33.5-88.9-88 0-27.1 16.5-51 49.4-91.9 4.7 5.6 67.1 88.1 67.1 88.1l39.8-47c2.8 4.8 5.4 9.5 7.7 14 18.6 36.7 10.8 83.6-22.6 107.8z";
    internal static readonly IconDefinition IconDefinition = new(name: "DumpsterFireIcon", height: 512, width: 640, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
