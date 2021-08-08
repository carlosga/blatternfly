namespace Blatternfly.Components
{
    public sealed class EggIcon : BaseIcon
    {
        public static readonly string SvgPath = "M192 0C86 0 0 214 0 320s86 192 192 192 192-86 192-192S298 0 192 0z";
        public static readonly IconDefinition IconDefinition = new(name: "EggIcon", height: 512, width: 384, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
