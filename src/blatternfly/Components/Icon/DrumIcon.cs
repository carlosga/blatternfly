namespace Blatternfly.Components
{
    public sealed class DrumIcon : BaseIcon
    {
        private static readonly string _svgPath = "M431.34 122.05l73.53-47.42a16 16 0 0 0 4.44-22.19l-8.87-13.31a16 16 0 0 0-22.19-4.44l-110.06 71C318.43 96.91 271.22 96 256 96 219.55 96 0 100.55 0 208.15v160.23c0 30.27 27.5 57.68 72 77.86v-101.9a24 24 0 1 1 48 0v118.93c33.05 9.11 71.07 15.06 112 16.73V376.39a24 24 0 1 1 48 0V480c40.93-1.67 78.95-7.62 112-16.73V344.34a24 24 0 1 1 48 0v101.9c44.5-20.18 72-47.59 72-77.86V208.15c0-43.32-35.76-69.76-80.66-86.1zM256 272.24c-114.88 0-208-28.69-208-64.09s93.12-64.08 208-64.08c17.15 0 33.73.71 49.68 1.91l-72.81 47a16 16 0 0 0-4.43 22.19l8.87 13.31a16 16 0 0 0 22.19 4.44l118.64-76.52C430.09 168 464 186.84 464 208.15c0 35.4-93.13 64.09-208 64.09z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "DrumIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public DrumIcon() : base(_definition) { }
    }
}