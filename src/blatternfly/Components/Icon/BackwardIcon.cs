namespace Blatternfly.Components
{
    public sealed class BackwardIcon : BaseIcon
    {
        private static readonly string _svgPath = "M11.5 280.6l192 160c20.6 17.2 52.5 2.8 52.5-24.6V96c0-27.4-31.9-41.8-52.5-24.6l-192 160c-15.3 12.8-15.3 36.4 0 49.2zm256 0l192 160c20.6 17.2 52.5 2.8 52.5-24.6V96c0-27.4-31.9-41.8-52.5-24.6l-192 160c-15.3 12.8-15.3 36.4 0 49.2z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "BackwardIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public BackwardIcon() : base(_definition) { }
    }
}