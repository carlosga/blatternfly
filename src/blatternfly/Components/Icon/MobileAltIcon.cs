namespace Blatternfly.Components
{
    public sealed class MobileAltIcon : BaseIcon
    {
        private static readonly string _svgPath = "M272 0H48C21.5 0 0 21.5 0 48v416c0 26.5 21.5 48 48 48h224c26.5 0 48-21.5 48-48V48c0-26.5-21.5-48-48-48zM160 480c-17.7 0-32-14.3-32-32s14.3-32 32-32 32 14.3 32 32-14.3 32-32 32zm112-108c0 6.6-5.4 12-12 12H60c-6.6 0-12-5.4-12-12V60c0-6.6 5.4-12 12-12h200c6.6 0 12 5.4 12 12v312z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "MobileAltIcon", height: 512, width: 320, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public MobileAltIcon() : base(_definition) { }
    }
}