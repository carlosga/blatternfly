namespace Blatternfly.Components
{
    public sealed class ShapesIcon : BaseIcon
    {
        private static readonly string _svgPath = "M128,256A128,128,0,1,0,256,384,128,128,0,0,0,128,256Zm379-54.86L400.07,18.29a37.26,37.26,0,0,0-64.14,0L229,201.14C214.76,225.52,232.58,256,261.09,256H474.91C503.42,256,521.24,225.52,507,201.14ZM480,288H320a32,32,0,0,0-32,32V480a32,32,0,0,0,32,32H480a32,32,0,0,0,32-32V320A32,32,0,0,0,480,288Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ShapesIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ShapesIcon() : base(_definition) { }
    }
}