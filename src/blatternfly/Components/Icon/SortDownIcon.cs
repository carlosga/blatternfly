namespace Blatternfly.Components
{
    public sealed class SortDownIcon : BaseIcon
    {
        private static readonly string _svgPath = "M41 288h238c21.4 0 32.1 25.9 17 41L177 448c-9.4 9.4-24.6 9.4-33.9 0L24 329c-15.1-15.1-4.4-41 17-41z";
        private static readonly IconDefinition _definition = new(name: "SortDownIcon", height: 512, width: 320, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
