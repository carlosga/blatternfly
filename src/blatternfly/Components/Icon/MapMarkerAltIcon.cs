namespace Blatternfly.Components
{
    public sealed class MapMarkerAltIcon : BaseIcon
    {
        private static readonly string _svgPath = "M172.268 501.67C26.97 291.031 0 269.413 0 192 0 85.961 85.961 0 192 0s192 85.961 192 192c0 77.413-26.97 99.031-172.268 309.67-9.535 13.774-29.93 13.773-39.464 0zM192 272c44.183 0 80-35.817 80-80s-35.817-80-80-80-80 35.817-80 80 35.817 80 80 80z";
        private static readonly IconDefinition _definition = new(name: "MapMarkerAltIcon", height: 512, width: 384, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}