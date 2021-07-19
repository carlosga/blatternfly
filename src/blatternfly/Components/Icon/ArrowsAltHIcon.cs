namespace Blatternfly.Components
{
    public sealed class ArrowsAltHIcon : BaseIcon
    {
        private static readonly string _svgPath = "M377.941 169.941V216H134.059v-46.059c0-21.382-25.851-32.09-40.971-16.971L7.029 239.029c-9.373 9.373-9.373 24.568 0 33.941l86.059 86.059c15.119 15.119 40.971 4.411 40.971-16.971V296h243.882v46.059c0 21.382 25.851 32.09 40.971 16.971l86.059-86.059c9.373-9.373 9.373-24.568 0-33.941l-86.059-86.059c-15.119-15.12-40.971-4.412-40.971 16.97z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ArrowsAltHIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ArrowsAltHIcon() : base(_definition) { }
    }
}