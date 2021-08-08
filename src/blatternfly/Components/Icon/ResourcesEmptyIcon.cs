namespace Blatternfly.Components
{
    public sealed class ResourcesEmptyIcon : BaseIcon
    {
        public static readonly string SvgPath = "M512,896 C300.2,896 128,723.9 128,512 C128,300.3 300.2,128 512,128 C723.7,128 896,300.2 896,512 C896,723.8 723.7,896 512,896 L512,896 Z M512.1,0 C229.7,0 0,229.8 0,512 C0,794.3 229.8,1024 512.1,1024 C794.4,1024 1024,794.3 1024,512 C1024,229.7 794.4,0 512.1,0 L512.1,0 Z";
        public static readonly IconDefinition IconDefinition = new(name: "ResourcesEmptyIcon", height: 1024, width: 1024, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
