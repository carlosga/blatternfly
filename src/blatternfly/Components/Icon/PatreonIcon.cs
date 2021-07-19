namespace Blatternfly.Components
{
    public sealed class PatreonIcon : BaseIcon
    {
        private static readonly string _svgPath = "M512 194.8c0 101.3-82.4 183.8-183.8 183.8-101.7 0-184.4-82.4-184.4-183.8 0-101.6 82.7-184.3 184.4-184.3C429.6 10.5 512 93.2 512 194.8zM0 501.5h90v-491H0v491z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "PatreonIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public PatreonIcon() : base(_definition) { }
    }
}