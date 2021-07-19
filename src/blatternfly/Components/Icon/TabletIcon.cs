namespace Blatternfly.Components
{
    public sealed class TabletIcon : BaseIcon
    {
        private static readonly string _svgPath = "M400 0H48C21.5 0 0 21.5 0 48v416c0 26.5 21.5 48 48 48h352c26.5 0 48-21.5 48-48V48c0-26.5-21.5-48-48-48zM224 480c-17.7 0-32-14.3-32-32s14.3-32 32-32 32 14.3 32 32-14.3 32-32 32z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "TabletIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public TabletIcon() : base(_definition) { }
    }
}