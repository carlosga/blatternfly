namespace Blatternfly.Components
{
    public sealed class MercuryIcon : BaseIcon
    {
        private static readonly string _svgPath = "M288 208c0-44.2-19.9-83.7-51.2-110.1 2.5-1.8 4.9-3.8 7.2-5.8 24.7-21.2 39.8-48.8 43.2-78.8.9-7.1-4.7-13.3-11.9-13.3h-40.5C229 0 224.1 4.1 223 9.8c-2.4 12.5-9.6 24.3-20.7 33.8C187 56.8 166.3 64 144 64s-43-7.2-58.4-20.4C74.5 34.1 67.4 22.3 64.9 9.8 63.8 4.1 58.9 0 53.2 0H12.7C5.5 0-.1 6.2.8 13.3 4.2 43.4 19.2 71 44 92.2c2.3 2 4.7 3.9 7.2 5.8C19.9 124.3 0 163.8 0 208c0 68.5 47.9 125.9 112 140.4V400H76c-6.6 0-12 5.4-12 12v40c0 6.6 5.4 12 12 12h36v36c0 6.6 5.4 12 12 12h40c6.6 0 12-5.4 12-12v-36h36c6.6 0 12-5.4 12-12v-40c0-6.6-5.4-12-12-12h-36v-51.6c64.1-14.5 112-71.9 112-140.4zm-224 0c0-44.1 35.9-80 80-80s80 35.9 80 80-35.9 80-80 80-80-35.9-80-80z";
        private static readonly IconDefinition _definition = new(name: "MercuryIcon", height: 512, width: 288, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}