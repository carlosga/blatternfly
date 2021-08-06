namespace Blatternfly.Components
{
    public sealed class TengeIcon : BaseIcon
    {
        private static readonly string _svgPath = "M372 160H12c-6.6 0-12 5.4-12 12v56c0 6.6 5.4 12 12 12h140v228c0 6.6 5.4 12 12 12h56c6.6 0 12-5.4 12-12V240h140c6.6 0 12-5.4 12-12v-56c0-6.6-5.4-12-12-12zm0-128H12C5.4 32 0 37.4 0 44v56c0 6.6 5.4 12 12 12h360c6.6 0 12-5.4 12-12V44c0-6.6-5.4-12-12-12z";
        private static readonly IconDefinition _definition = new(name: "TengeIcon", height: 512, width: 384, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}