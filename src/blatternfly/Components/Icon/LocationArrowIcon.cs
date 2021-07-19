namespace Blatternfly.Components
{
    public sealed class LocationArrowIcon : BaseIcon
    {
        private static readonly string _svgPath = "M444.52 3.52L28.74 195.42c-47.97 22.39-31.98 92.75 19.19 92.75h175.91v175.91c0 51.17 70.36 67.17 92.75 19.19l191.9-415.78c15.99-38.39-25.59-79.97-63.97-63.97z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "LocationArrowIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public LocationArrowIcon() : base(_definition) { }
    }
}