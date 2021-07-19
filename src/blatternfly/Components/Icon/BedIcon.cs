namespace Blatternfly.Components
{
    public sealed class BedIcon : BaseIcon
    {
        private static readonly string _svgPath = "M176 256c44.11 0 80-35.89 80-80s-35.89-80-80-80-80 35.89-80 80 35.89 80 80 80zm352-128H304c-8.84 0-16 7.16-16 16v144H64V80c0-8.84-7.16-16-16-16H16C7.16 64 0 71.16 0 80v352c0 8.84 7.16 16 16 16h32c8.84 0 16-7.16 16-16v-48h512v48c0 8.84 7.16 16 16 16h32c8.84 0 16-7.16 16-16V240c0-61.86-50.14-112-112-112z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "BedIcon", height: 512, width: 640, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public BedIcon() : base(_definition) { }
    }
}