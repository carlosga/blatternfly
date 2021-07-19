namespace Blatternfly.Components
{
    public sealed class BowlingBallIcon : BaseIcon
    {
        private static readonly string _svgPath = "M248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zM120 192c-17.7 0-32-14.3-32-32s14.3-32 32-32 32 14.3 32 32-14.3 32-32 32zm64-96c0-17.7 14.3-32 32-32s32 14.3 32 32-14.3 32-32 32-32-14.3-32-32zm48 144c-17.7 0-32-14.3-32-32s14.3-32 32-32 32 14.3 32 32-14.3 32-32 32z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "BowlingBallIcon", height: 512, width: 496, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public BowlingBallIcon() : base(_definition) { }
    }
}