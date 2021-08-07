namespace Blatternfly.Components
{
    public sealed class ServicestackIcon : BaseIcon
    {
        private static readonly string _svgPath = "M88 216c81.7 10.2 273.7 102.3 304 232H0c99.5-8.1 184.5-137 88-232zm32-152c32.3 35.6 47.7 83.9 46.4 133.6C249.3 231.3 373.7 321.3 400 448h96C455.3 231.9 222.8 79.5 120 64z";
        private static readonly IconDefinition _definition = new(name: "ServicestackIcon", height: 512, width: 496, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
