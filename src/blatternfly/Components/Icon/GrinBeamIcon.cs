namespace Blatternfly.Components
{
    public sealed class GrinBeamIcon : BaseIcon
    {
        private static readonly string _svgPath = "M248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zm80 144c23.8 0 52.7 29.3 56 71.4.7 8.6-10.8 11.9-14.9 4.5l-9.5-17c-7.7-13.7-19.2-21.6-31.5-21.6s-23.8 7.9-31.5 21.6l-9.5 17c-4.1 7.3-15.6 4-14.9-4.5 3.1-42.1 32-71.4 55.8-71.4zm-160 0c23.8 0 52.7 29.3 56 71.4.7 8.6-10.8 11.9-14.9 4.5l-9.5-17c-7.7-13.7-19.2-21.6-31.5-21.6s-23.8 7.9-31.5 21.6l-9.5 17c-4.2 7.4-15.6 4-14.9-4.5 3.1-42.1 32-71.4 55.8-71.4zm80 280c-60.6 0-134.5-38.3-143.8-93.3-2-11.9 9.4-21.6 20.7-17.9C155.1 330.5 200 336 248 336s92.9-5.5 123.1-15.2c11.4-3.7 22.6 6.1 20.7 17.9-9.3 55-83.2 93.3-143.8 93.3z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "GrinBeamIcon", height: 512, width: 496, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public GrinBeamIcon() : base(_definition) { }
    }
}