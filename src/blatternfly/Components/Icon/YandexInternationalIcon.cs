namespace Blatternfly.Components
{
    public sealed class YandexInternationalIcon : BaseIcon
    {
        private static readonly string _svgPath = "M129.5 512V345.9L18.5 48h55.8l81.8 229.7L250.2 0h51.3L180.8 347.8V512h-51.3z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "YandexInternationalIcon", height: 512, width: 320, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public YandexInternationalIcon() : base(_definition) { }
    }
}