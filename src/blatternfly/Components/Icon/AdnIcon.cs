namespace Blatternfly.Components
{
    public sealed class AdnIcon : BaseIcon
    {
        private static readonly string _svgPath = "M248 167.5l64.9 98.8H183.1l64.9-98.8zM496 256c0 136.9-111.1 248-248 248S0 392.9 0 256 111.1 8 248 8s248 111.1 248 248zm-99.8 82.7L248 115.5 99.8 338.7h30.4l33.6-51.7h168.6l33.6 51.7h30.2z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "AdnIcon", height: 512, width: 496, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public AdnIcon() : base(_definition) { }
    }
}