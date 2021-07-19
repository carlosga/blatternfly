namespace Blatternfly.Components
{
    public sealed class ArrowAltCircleUpIcon : BaseIcon
    {
        private static readonly string _svgPath = "M8 256C8 119 119 8 256 8s248 111 248 248-111 248-248 248S8 393 8 256zm292 116V256h70.9c10.7 0 16.1-13 8.5-20.5L264.5 121.2c-4.7-4.7-12.2-4.7-16.9 0l-115 114.3c-7.6 7.6-2.2 20.5 8.5 20.5H212v116c0 6.6 5.4 12 12 12h64c6.6 0 12-5.4 12-12z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ArrowAltCircleUpIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ArrowAltCircleUpIcon() : base(_definition) { }
    }
}