namespace Blatternfly.Components
{
    public sealed class BookmarkIcon : BaseIcon
    {
        public static readonly string SvgPath = "M0 512V48C0 21.49 21.49 0 48 0h288c26.51 0 48 21.49 48 48v464L192 400 0 512z";
        public static readonly IconDefinition IconDefinition = new(name: "BookmarkIcon", height: 512, width: 384, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
