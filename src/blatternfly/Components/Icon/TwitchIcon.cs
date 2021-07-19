namespace Blatternfly.Components
{
    public sealed class TwitchIcon : BaseIcon
    {
        private static readonly string _svgPath = "M391.17,103.47H352.54v109.7h38.63ZM285,103H246.37V212.75H285ZM120.83,0,24.31,91.42V420.58H140.14V512l96.53-91.42h77.25L487.69,256V0ZM449.07,237.75l-77.22,73.12H294.61l-67.6,64v-64H140.14V36.58H449.07Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "TwitchIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public TwitchIcon() : base(_definition) { }
    }
}