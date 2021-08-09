namespace Blatternfly.Components
{
    public sealed class ThinkPeaksIcon : BaseIcon
    {
        private static readonly string _svgPath = "M465.4 409.4l87.1-150.2-32-.3-55.1 95L259.2 0 23 407.4l32 .3L259.2 55.6zm-355.3-44.1h32.1l117.4-202.5L463 511.9l32.5.1-235.8-404.6z";
        public static readonly IconDefinition IconDefinition = new(name: "ThinkPeaksIcon", height: 512, width: 576, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}