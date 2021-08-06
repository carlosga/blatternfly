namespace Blatternfly.Components
{
    public sealed class StravaIcon : BaseIcon
    {
        private static readonly string _svgPath = "M158.4 0L7 292h89.2l62.2-116.1L220.1 292h88.5zm150.2 292l-43.9 88.2-44.6-88.2h-67.6l112.2 220 111.5-220z";
        private static readonly IconDefinition _definition = new(name: "StravaIcon", height: 512, width: 384, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}