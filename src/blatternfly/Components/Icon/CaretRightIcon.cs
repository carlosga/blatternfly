namespace Blatternfly.Components
{
    public sealed class CaretRightIcon : BaseIcon
    {
        public static readonly string SvgPath = "M0 384.662V127.338c0-17.818 21.543-26.741 34.142-14.142l128.662 128.662c7.81 7.81 7.81 20.474 0 28.284L34.142 398.804C21.543 411.404 0 402.48 0 384.662z";
        public static readonly IconDefinition IconDefinition = new(name: "CaretRightIcon", height: 512, width: 192, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
