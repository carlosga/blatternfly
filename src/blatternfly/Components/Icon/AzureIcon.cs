namespace Blatternfly.Components
{
    public sealed class AzureIcon : BaseIcon
    {
        public static readonly string SvgPath = "m88.33 0-47.66 41.33-40.67 73h36.67zm6.34 9.67-20.34 57.33 39 49-75.66 13h124z";
        public static readonly IconDefinition IconDefinition = new(name: "AzureIcon", height: 150, width: 160, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
