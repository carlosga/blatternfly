namespace Blatternfly.Components
{
    public sealed class WindowMinimizeIcon : BaseIcon
    {
        public static readonly string SvgPath = "M464 352H48c-26.5 0-48 21.5-48 48v32c0 26.5 21.5 48 48 48h416c26.5 0 48-21.5 48-48v-32c0-26.5-21.5-48-48-48z";
        public static readonly IconDefinition IconDefinition = new(name: "WindowMinimizeIcon", height: 512, width: 512, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
