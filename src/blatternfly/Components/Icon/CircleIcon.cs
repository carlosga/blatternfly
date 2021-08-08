namespace Blatternfly.Components
{
    public sealed class CircleIcon : BaseIcon
    {
        public static readonly string SvgPath = "M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8z";
        public static readonly IconDefinition IconDefinition = new(name: "CircleIcon", height: 512, width: 512, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
