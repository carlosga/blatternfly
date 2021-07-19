namespace Blatternfly.Components
{
    public sealed class DotCircleIcon : BaseIcon
    {
        private static readonly string _svgPath = "M256 8C119.033 8 8 119.033 8 256s111.033 248 248 248 248-111.033 248-248S392.967 8 256 8zm80 248c0 44.112-35.888 80-80 80s-80-35.888-80-80 35.888-80 80-80 80 35.888 80 80z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "DotCircleIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public DotCircleIcon() : base(_definition) { }
    }
}