namespace Blatternfly.Components;

/// <summary>KaggleIcon icon.</summary>
public sealed class KaggleIcon : BaseIcon
{
    private static readonly string _svgPath = "M304.2 501.5L158.4 320.3 298.2 185c2.6-2.7 1.7-10.5-5.3-10.5h-69.2c-3.5 0-7 1.8-10.5 5.3L80.9 313.5V7.5q0-7.5-7.5-7.5H21.5Q14 0 14 7.5v497q0 7.5 7.5 7.5h51.9q7.5 0 7.5-7.5v-109l30.8-29.3 110.5 140.6c3 3.5 6.5 5.3 10.5 5.3h66.9q5.25 0 6-3z";
    internal static readonly IconDefinition IconDefinition = new(name: "KaggleIcon", height: 512, width: 320, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

    protected override IconDefinition Definition { get => IconDefinition; }
}
