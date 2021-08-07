namespace Blatternfly.Components
{
    public sealed class MapMarkerIcon : BaseIcon
    {
        private static readonly string _svgPath = "M172.268 501.67C26.97 291.031 0 269.413 0 192 0 85.961 85.961 0 192 0s192 85.961 192 192c0 77.413-26.97 99.031-172.268 309.67-9.535 13.774-29.93 13.773-39.464 0z";
        private static readonly IconDefinition _definition = new(name: "MapMarkerIcon", height: 512, width: 384, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
