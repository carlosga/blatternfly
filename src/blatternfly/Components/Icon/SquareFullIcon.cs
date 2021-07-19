namespace Blatternfly.Components
{
    public sealed class SquareFullIcon : BaseIcon
    {
        private static readonly string _svgPath = "M512 512H0V0h512v512z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "SquareFullIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public SquareFullIcon() : base(_definition) { }
    }
}