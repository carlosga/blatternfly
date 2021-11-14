namespace Blatternfly.Components;

public sealed class IconDefinition
{
    public readonly string Name;
    public readonly int    Height;
    public readonly int    Width;
    public readonly string SvgPath;
    public readonly string OffsetY;
    public readonly string OffsetX;
    public readonly string Transform;

    public IconDefinition(
        string name      = ""
      , int    height    = 0
      , int    width     = 0
      , string svgPath   = ""
      , string offsetY   = ""
      , string offsetX   = ""
      , string transform = null
    )
    {
        Name      = name;
        Height    = height;
        Width     = width;
        SvgPath   = svgPath;
        OffsetY   = offsetY;
        OffsetX   = offsetX;
        Transform = transform;
    }

    private string OffsetXValue { get => (!string.IsNullOrEmpty(OffsetX) ? OffsetX : "0"); }
    private string OffsetYValue { get => (!string.IsNullOrEmpty(OffsetY) ? OffsetY : "0"); }

    public string ViewBox => $"{OffsetXValue} {OffsetYValue} {Width} {Height}";
}
