namespace Blatternfly.Components
{
    public sealed class YandexInternationalIcon : BaseIcon
    {
        private static readonly string _svgPath = "M129.5 512V345.9L18.5 48h55.8l81.8 229.7L250.2 0h51.3L180.8 347.8V512h-51.3z";
        public static readonly IconDefinition IconDefinition = new(name: "YandexInternationalIcon", height: 512, width: 320, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}