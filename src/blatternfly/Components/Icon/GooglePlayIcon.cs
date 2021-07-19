namespace Blatternfly.Components
{
    public sealed class GooglePlayIcon : BaseIcon
    {
        private static readonly string _svgPath = "M325.3 234.3L104.6 13l280.8 161.2-60.1 60.1zM47 0C34 6.8 25.3 19.2 25.3 35.3v441.3c0 16.1 8.7 28.5 21.7 35.3l256.6-256L47 0zm425.2 225.6l-58.9-34.1-65.7 64.5 65.7 64.5 60.1-34.1c18-14.3 18-46.5-1.2-60.8zM104.6 499l280.8-161.2-60.1-60.1L104.6 499z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "GooglePlayIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public GooglePlayIcon() : base(_definition) { }
    }
}