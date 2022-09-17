namespace Blatternfly.Components;

/// <summary>TintSlashIcon icon.</summary>
public sealed class TintSlashIcon : BaseIcon
{
    private static readonly string _svgPath = "M633.82 458.1L494.97 350.78c.52-5.57 1.03-11.16 1.03-16.87 0-111.76-99.79-153.34-146.78-311.82-7.94-28.78-49.44-30.12-58.44 0-15.52 52.34-36.87 91.96-58.49 125.68L45.47 3.37C38.49-2.05 28.43-.8 23.01 6.18L3.37 31.45C-2.05 38.42-.8 48.47 6.18 53.9l588.36 454.73c6.98 5.43 17.03 4.17 22.46-2.81l19.64-25.27c5.41-6.97 4.16-17.02-2.82-22.45zM144 333.91C144 432.35 222.72 512 320 512c44.71 0 85.37-16.96 116.4-44.7L162.72 255.78c-11.41 23.5-18.72 48.35-18.72 78.13z";
    internal static readonly IconDefinition IconDefinition = new(name: "TintSlashIcon", height: 512, width: 640, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
