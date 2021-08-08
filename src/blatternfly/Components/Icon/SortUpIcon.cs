namespace Blatternfly.Components
{
    public sealed class SortUpIcon : BaseIcon
    {
        public static readonly string SvgPath = "M279 224H41c-21.4 0-32.1-25.9-17-41L143 64c9.4-9.4 24.6-9.4 33.9 0l119 119c15.2 15.1 4.5 41-16.9 41z";
        public static readonly IconDefinition IconDefinition = new(name: "SortUpIcon", height: 512, width: 320, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
