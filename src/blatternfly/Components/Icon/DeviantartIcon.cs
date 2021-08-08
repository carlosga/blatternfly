namespace Blatternfly.Components
{
    public sealed class DeviantartIcon : BaseIcon
    {
        public static readonly string SvgPath = "M320 93.2l-98.2 179.1 7.4 9.5H320v127.7H159.1l-13.5 9.2-43.7 84c-.3 0-8.6 8.6-9.2 9.2H0v-93.2l93.2-179.4-7.4-9.2H0V102.5h156l13.5-9.2 43.7-84c.3 0 8.6-8.6 9.2-9.2H320v93.1z";
        public static readonly IconDefinition IconDefinition = new(name: "DeviantartIcon", height: 512, width: 320, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
