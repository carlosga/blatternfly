namespace Blatternfly.Components
{
    public sealed class ColumnsIcon : BaseIcon
    {
        private static readonly string _svgPath = "M464 32H48C21.49 32 0 53.49 0 80v352c0 26.51 21.49 48 48 48h416c26.51 0 48-21.49 48-48V80c0-26.51-21.49-48-48-48zM224 416H64V160h160v256zm224 0H288V160h160v256z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ColumnsIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ColumnsIcon() : base(_definition) { }
    }
}