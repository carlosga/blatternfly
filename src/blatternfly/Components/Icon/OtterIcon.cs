namespace Blatternfly.Components
{
    public sealed class OtterIcon : BaseIcon
    {
        private static readonly string _svgPath = "M608 32h-32l-13.25-13.25A63.97 63.97 0 0 0 517.49 0H497c-11.14 0-22.08 2.91-31.75 8.43L312 96h-56C149.96 96 64 181.96 64 288v1.61c0 32.75-16 62.14-39.56 84.89-18.19 17.58-28.1 43.68-23.19 71.8 6.76 38.8 42.9 65.7 82.28 65.7H192c17.67 0 32-14.33 32-32s-14.33-32-32-32H80c-8.83 0-16-7.17-16-16s7.17-16 16-16h224c8.84 0 16-7.16 16-16v-16c0-17.67-14.33-32-32-32h-64l149.49-80.5L448 416h80c8.84 0 16-7.16 16-16v-16c0-17.67-14.33-32-32-32h-28.22l-55.11-110.21L521.14 192H544c53.02 0 96-42.98 96-96V64c0-17.67-14.33-32-32-32zm-96 16c8.84 0 16 7.16 16 16s-7.16 16-16 16-16-7.16-16-16 7.16-16 16-16zm32 96h-34.96L407.2 198.84l-13.77-27.55L512 112h77.05c-6.62 18.58-24.22 32-45.05 32z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "OtterIcon", height: 512, width: 640, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public OtterIcon() : base(_definition) { }
    }
}