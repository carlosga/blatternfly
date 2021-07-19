namespace Blatternfly.Components
{
    public sealed class FastBackwardIcon : BaseIcon
    {
        private static readonly string _svgPath = "M0 436V76c0-6.6 5.4-12 12-12h40c6.6 0 12 5.4 12 12v151.9L235.5 71.4C256.1 54.3 288 68.6 288 96v131.9L459.5 71.4C480.1 54.3 512 68.6 512 96v320c0 27.4-31.9 41.7-52.5 24.6L288 285.3V416c0 27.4-31.9 41.7-52.5 24.6L64 285.3V436c0 6.6-5.4 12-12 12H12c-6.6 0-12-5.4-12-12z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "FastBackwardIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public FastBackwardIcon() : base(_definition) { }
    }
}