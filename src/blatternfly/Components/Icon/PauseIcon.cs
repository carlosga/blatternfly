namespace Blatternfly.Components
{
    public sealed class PauseIcon : BaseIcon
    {
        private static readonly string _svgPath = "M144 479H48c-26.5 0-48-21.5-48-48V79c0-26.5 21.5-48 48-48h96c26.5 0 48 21.5 48 48v352c0 26.5-21.5 48-48 48zm304-48V79c0-26.5-21.5-48-48-48h-96c-26.5 0-48 21.5-48 48v352c0 26.5 21.5 48 48 48h96c26.5 0 48-21.5 48-48z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "PauseIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public PauseIcon() : base(_definition) { }
    }
}