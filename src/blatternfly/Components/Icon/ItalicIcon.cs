namespace Blatternfly.Components
{
    public sealed class ItalicIcon : BaseIcon
    {
        private static readonly string _svgPath = "M320 48v32a16 16 0 0 1-16 16h-62.76l-80 320H208a16 16 0 0 1 16 16v32a16 16 0 0 1-16 16H16a16 16 0 0 1-16-16v-32a16 16 0 0 1 16-16h62.76l80-320H112a16 16 0 0 1-16-16V48a16 16 0 0 1 16-16h192a16 16 0 0 1 16 16z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ItalicIcon", height: 512, width: 320, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ItalicIcon() : base(_definition) { }
    }
}