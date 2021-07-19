namespace Blatternfly.Components
{
    public sealed class PlusIcon : BaseIcon
    {
        private static readonly string _svgPath = "M416 208H272V64c0-17.67-14.33-32-32-32h-32c-17.67 0-32 14.33-32 32v144H32c-17.67 0-32 14.33-32 32v32c0 17.67 14.33 32 32 32h144v144c0 17.67 14.33 32 32 32h32c17.67 0 32-14.33 32-32V304h144c17.67 0 32-14.33 32-32v-32c0-17.67-14.33-32-32-32z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "PlusIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public PlusIcon() : base(_definition) { }
    }
}