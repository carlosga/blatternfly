namespace Blatternfly.Components
{
    public sealed class GripLinesIcon : BaseIcon
    {
        private static readonly string _svgPath = "M496 288H16c-8.8 0-16 7.2-16 16v32c0 8.8 7.2 16 16 16h480c8.8 0 16-7.2 16-16v-32c0-8.8-7.2-16-16-16zm0-128H16c-8.8 0-16 7.2-16 16v32c0 8.8 7.2 16 16 16h480c8.8 0 16-7.2 16-16v-32c0-8.8-7.2-16-16-16z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "GripLinesIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public GripLinesIcon() : base(_definition) { }
    }
}