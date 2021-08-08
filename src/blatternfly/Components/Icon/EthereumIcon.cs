namespace Blatternfly.Components
{
    public sealed class EthereumIcon : BaseIcon
    {
        public static readonly string SvgPath = "M311.9 260.8L160 353.6 8 260.8 160 0l151.9 260.8zM160 383.4L8 290.6 160 512l152-221.4-152 92.8z";
        public static readonly IconDefinition IconDefinition = new(name: "EthereumIcon", height: 512, width: 320, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
