namespace Blatternfly.Components
{
    public sealed class GripLinesVerticalIcon : BaseIcon
    {
        public static readonly string SvgPath = "M96 496V16c0-8.8-7.2-16-16-16H48c-8.8 0-16 7.2-16 16v480c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16zm128 0V16c0-8.8-7.2-16-16-16h-32c-8.8 0-16 7.2-16 16v480c0 8.8 7.2 16 16 16h32c8.8 0 16-7.2 16-16z";
        public static readonly IconDefinition IconDefinition = new(name: "GripLinesVerticalIcon", height: 512, width: 256, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
