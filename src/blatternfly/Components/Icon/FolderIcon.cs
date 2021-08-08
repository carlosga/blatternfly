namespace Blatternfly.Components
{
    public sealed class FolderIcon : BaseIcon
    {
        public static readonly string SvgPath = "M464 128H272l-64-64H48C21.49 64 0 85.49 0 112v288c0 26.51 21.49 48 48 48h416c26.51 0 48-21.49 48-48V176c0-26.51-21.49-48-48-48z";
        public static readonly IconDefinition IconDefinition = new(name: "FolderIcon", height: 512, width: 512, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
