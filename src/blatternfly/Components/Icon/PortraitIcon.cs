namespace Blatternfly.Components
{
    public sealed class PortraitIcon : BaseIcon
    {
        private static readonly string _svgPath = "M336 0H48C21.5 0 0 21.5 0 48v416c0 26.5 21.5 48 48 48h288c26.5 0 48-21.5 48-48V48c0-26.5-21.5-48-48-48zM192 128c35.3 0 64 28.7 64 64s-28.7 64-64 64-64-28.7-64-64 28.7-64 64-64zm112 236.8c0 10.6-10 19.2-22.4 19.2H102.4C90 384 80 375.4 80 364.8v-19.2c0-31.8 30.1-57.6 67.2-57.6h5c12.3 5.1 25.7 8 39.8 8s27.6-2.9 39.8-8h5c37.1 0 67.2 25.8 67.2 57.6v19.2z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "PortraitIcon", height: 512, width: 384, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public PortraitIcon() : base(_definition) { }
    }
}