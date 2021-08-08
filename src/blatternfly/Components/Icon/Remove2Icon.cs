namespace Blatternfly.Components
{
    public sealed class Remove2Icon : BaseIcon
    {
        public static readonly string SvgPath = "M576,128 L576,0 L320,0 L320,128 L0,128 L0,320 L64,256 L832,256 L896,320 L896,128 L576,128 Z M512,128 L384,128 L384,64 L512,64 L512,128 Z M64,320 L128,1024 L731.4,1024 L832,320 L64,320 Z";
        public static readonly IconDefinition IconDefinition = new(name: "Remove2Icon", height: 1024, width: 896, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
