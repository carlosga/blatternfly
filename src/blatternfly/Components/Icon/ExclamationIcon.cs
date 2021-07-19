namespace Blatternfly.Components
{
    public sealed class ExclamationIcon : BaseIcon
    {
        private static readonly string _svgPath = "M176 432c0 44.112-35.888 80-80 80s-80-35.888-80-80 35.888-80 80-80 80 35.888 80 80zM25.26 25.199l13.6 272C39.499 309.972 50.041 320 62.83 320h66.34c12.789 0 23.331-10.028 23.97-22.801l13.6-272C167.425 11.49 156.496 0 142.77 0H49.23C35.504 0 24.575 11.49 25.26 25.199z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ExclamationIcon", height: 512, width: 192, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ExclamationIcon() : base(_definition) { }
    }
}