namespace Blatternfly.Components
{
    public sealed class BandcampIcon : BaseIcon
    {
        public static readonly string SvgPath = "M256,8C119,8,8,119,8,256S119,504,256,504,504,393,504,256,393,8,256,8Zm48.2,326.1h-181L207.9,178h181Z";
        public static readonly IconDefinition IconDefinition = new(name: "BandcampIcon", height: 512, width: 512, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
