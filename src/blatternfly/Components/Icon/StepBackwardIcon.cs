namespace Blatternfly.Components
{
    public sealed class StepBackwardIcon : BaseIcon
    {
        private static readonly string _svgPath = "M64 468V44c0-6.6 5.4-12 12-12h48c6.6 0 12 5.4 12 12v176.4l195.5-181C352.1 22.3 384 36.6 384 64v384c0 27.4-31.9 41.7-52.5 24.6L136 292.7V468c0 6.6-5.4 12-12 12H76c-6.6 0-12-5.4-12-12z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "StepBackwardIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public StepBackwardIcon() : base(_definition) { }
    }
}