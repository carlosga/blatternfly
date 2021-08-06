namespace Blatternfly.Components
{
    public sealed class WindowMinimizeIcon : BaseIcon
    {
        private static readonly string _svgPath = "M464 352H48c-26.5 0-48 21.5-48 48v32c0 26.5 21.5 48 48 48h416c26.5 0 48-21.5 48-48v-32c0-26.5-21.5-48-48-48z";
        private static readonly IconDefinition _definition = new(name: "WindowMinimizeIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}