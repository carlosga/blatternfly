namespace Blatternfly.Components;

public sealed class CentercodeIcon : BaseIcon
{
    private static readonly string _svgPath = "M329.2 268.6c-3.8 35.2-35.4 60.6-70.6 56.8-35.2-3.8-60.6-35.4-56.8-70.6 3.8-35.2 35.4-60.6 70.6-56.8 35.1 3.8 60.6 35.4 56.8 70.6zm-85.8 235.1C96.7 496-8.2 365.5 10.1 224.3c11.2-86.6 65.8-156.9 139.1-192 161-77.1 349.7 37.4 354.7 216.6 4.1 147-118.4 262.2-260.5 254.8zm179.9-180c27.9-118-160.5-205.9-237.2-234.2-57.5 56.3-69.1 188.6-33.8 344.4 68.8 15.8 169.1-26.4 271-110.2z";
    public static readonly IconDefinition IconDefinition = new(name: "CentercodeIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
