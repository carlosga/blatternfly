namespace Blatternfly.Components
{
    public sealed class WaveSquareIcon : BaseIcon
    {
        private static readonly string _svgPath = "M476 480H324a36 36 0 0 1-36-36V96h-96v156a36 36 0 0 1-36 36H16a16 16 0 0 1-16-16v-32a16 16 0 0 1 16-16h112V68a36 36 0 0 1 36-36h152a36 36 0 0 1 36 36v348h96V260a36 36 0 0 1 36-36h140a16 16 0 0 1 16 16v32a16 16 0 0 1-16 16H512v156a36 36 0 0 1-36 36z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "WaveSquareIcon", height: 512, width: 640, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public WaveSquareIcon() : base(_definition) { }
    }
}