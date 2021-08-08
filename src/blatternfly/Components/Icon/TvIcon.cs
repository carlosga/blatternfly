namespace Blatternfly.Components
{
    public sealed class TvIcon : BaseIcon
    {
        public static readonly string SvgPath = "M592 0H48A48 48 0 0 0 0 48v320a48 48 0 0 0 48 48h240v32H112a16 16 0 0 0-16 16v32a16 16 0 0 0 16 16h416a16 16 0 0 0 16-16v-32a16 16 0 0 0-16-16H352v-32h240a48 48 0 0 0 48-48V48a48 48 0 0 0-48-48zm-16 352H64V64h512z";
        public static readonly IconDefinition IconDefinition = new(name: "TvIcon", height: 512, width: 640, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
