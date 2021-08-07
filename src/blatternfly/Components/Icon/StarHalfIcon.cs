namespace Blatternfly.Components
{
    public sealed class StarHalfIcon : BaseIcon
    {
        private static readonly string _svgPath = "M288 0c-11.4 0-22.8 5.9-28.7 17.8L194 150.2 47.9 171.4c-26.2 3.8-36.7 36.1-17.7 54.6l105.7 103-25 145.5c-4.5 26.1 23 46 46.4 33.7L288 439.6V0z";
        private static readonly IconDefinition _definition = new(name: "StarHalfIcon", height: 512, width: 576, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
