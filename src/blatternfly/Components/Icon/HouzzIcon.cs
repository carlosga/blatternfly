namespace Blatternfly.Components
{
    public sealed class HouzzIcon : BaseIcon
    {
        private static readonly string _svgPath = "M275.9 330.7H171.3V480H17V32h109.5v104.5l305.1 85.6V480H275.9z";
        public static readonly IconDefinition IconDefinition = new(name: "HouzzIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}