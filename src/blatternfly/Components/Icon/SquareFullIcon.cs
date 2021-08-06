namespace Blatternfly.Components
{
    public sealed class SquareFullIcon : BaseIcon
    {
        private static readonly string _svgPath = "M512 512H0V0h512v512z";
        private static readonly IconDefinition _definition = new(name: "SquareFullIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}