namespace Blatternfly.Components
{
    public sealed class SuitcaseIcon : BaseIcon
    {
        private static readonly string _svgPath = "M128 480h256V80c0-26.5-21.5-48-48-48H176c-26.5 0-48 21.5-48 48v400zm64-384h128v32H192V96zm320 80v256c0 26.5-21.5 48-48 48h-48V128h48c26.5 0 48 21.5 48 48zM96 480H48c-26.5 0-48-21.5-48-48V176c0-26.5 21.5-48 48-48h48v352z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "SuitcaseIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public SuitcaseIcon() : base(_definition) { }
    }
}