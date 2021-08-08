namespace Blatternfly.Components
{
    public sealed class SquareFullIcon : BaseIcon
    {
        public static readonly string SvgPath = "M512 512H0V0h512v512z";
        public static readonly IconDefinition IconDefinition = new(name: "SquareFullIcon", height: 512, width: 512, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
