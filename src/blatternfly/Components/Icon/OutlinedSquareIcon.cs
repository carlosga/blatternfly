namespace Blatternfly.Components
{
    public sealed class OutlinedSquareIcon : BaseIcon
    {
        private static readonly string _svgPath = "M400 32H48C21.5 32 0 53.5 0 80v352c0 26.5 21.5 48 48 48h352c26.5 0 48-21.5 48-48V80c0-26.5-21.5-48-48-48zm-6 400H54c-3.3 0-6-2.7-6-6V86c0-3.3 2.7-6 6-6h340c3.3 0 6 2.7 6 6v340c0 3.3-2.7 6-6 6z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "OutlinedSquareIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public OutlinedSquareIcon() : base(_definition) { }
    }
}