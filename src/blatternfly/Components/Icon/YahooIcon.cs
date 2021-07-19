namespace Blatternfly.Components
{
    public sealed class YahooIcon : BaseIcon
    {
        private static readonly string _svgPath = "M223.69,141.06,167,284.23,111,141.06H14.93L120.76,390.19,82.19,480h94.17L317.27,141.06Zm105.4,135.79a58.22,58.22,0,1,0,58.22,58.22A58.22,58.22,0,0,0,329.09,276.85ZM394.65,32l-93,223.47H406.44L499.07,32Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "YahooIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public YahooIcon() : base(_definition) { }
    }
}