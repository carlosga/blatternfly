namespace Blatternfly.Components
{
    public sealed class ScreenIcon : BaseIcon
    {
        private static readonly string _svgPath = "M1088,832 L1088,64 L0,64 L0,832 L448,832 L448,896 L256,896 L256,960 L832,960 L832,896 L640,896 L640,832 L1088,832 Z M128,704 L128,192 L960,192 L960,704 L128,704 Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ScreenIcon", height: 1024, width: 1088, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ScreenIcon() : base(_definition) { }
    }
}