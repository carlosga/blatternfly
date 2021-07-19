namespace Blatternfly.Components
{
    public partial class IconDefinition
    {
        public readonly string Name;
        public readonly int    Height;
        public readonly int    Width;
        public readonly string SvgPath;
        public readonly string YOffset;
        public readonly string XOffset;
        public readonly string Transform;

        public IconDefinition(
            string name = ""
          , int    height = 0
          , int    width = 0
          , string svgPath = ""
          , string yOffset = ""
          , string xOffset = ""
          , string transform = ""
        )
        {
            Name      = name;
            Height    = height;
            Width     = width;
            SvgPath   = svgPath;
            YOffset   = yOffset;
            XOffset   = xOffset;
            Transform = transform;
        }

        private string xOffsetValue => (!string.IsNullOrEmpty(XOffset) ? XOffset : "0");
        private string yOffsetValue => (!string.IsNullOrEmpty(YOffset) ? YOffset : "0");

        public string ViewBox => $"{xOffsetValue} {yOffsetValue} {Width} {Height}";
    }
}