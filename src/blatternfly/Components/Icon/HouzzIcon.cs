namespace Blatternfly.Components
{
    public sealed class HouzzIcon : BaseIcon
    {
        private static readonly string _svgPath = "M275.9 330.7H171.3V480H17V32h109.5v104.5l305.1 85.6V480H275.9z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "HouzzIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public HouzzIcon() : base(_definition) { }
    }
}