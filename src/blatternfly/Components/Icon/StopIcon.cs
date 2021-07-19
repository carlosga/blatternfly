namespace Blatternfly.Components
{
    public sealed class StopIcon : BaseIcon
    {
        private static readonly string _svgPath = "M400 32H48C21.5 32 0 53.5 0 80v352c0 26.5 21.5 48 48 48h352c26.5 0 48-21.5 48-48V80c0-26.5-21.5-48-48-48z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "StopIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public StopIcon() : base(_definition) { }
    }
}