namespace Blatternfly.Components
{
    public sealed class RecordVinylIcon : BaseIcon
    {
        private static readonly string _svgPath = "M256 152a104 104 0 1 0 104 104 104 104 0 0 0-104-104zm0 128a24 24 0 1 1 24-24 24 24 0 0 1-24 24zm0-272C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm0 376a128 128 0 1 1 128-128 128 128 0 0 1-128 128z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "RecordVinylIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public RecordVinylIcon() : base(_definition) { }
    }
}