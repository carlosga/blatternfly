namespace Blatternfly.Components
{
    public sealed class CrutchIcon : BaseIcon
    {
        private static readonly string _svgPath = "M507.31 185.71l-181-181a16 16 0 0 0-22.62 0L281 27.31a16 16 0 0 0 0 22.63l181 181a16 16 0 0 0 22.63 0l22.62-22.63a16 16 0 0 0 .06-22.6zm-179.54 66.41l-67.89-67.89 55.1-55.1-45.25-45.25-109.67 109.67a96.08 96.08 0 0 0-25.67 46.29L106.65 360.1l-102 102a16 16 0 0 0 0 22.63l22.62 22.62a16 16 0 0 0 22.63 0l102-102 120.25-27.75a95.88 95.88 0 0 0 46.29-25.65l109.68-109.68L382.87 197zm-54.57 54.57a32 32 0 0 1-15.45 8.54l-79.3 18.32 18.3-79.3a32.22 32.22 0 0 1 8.56-15.45l9.31-9.31 67.89 67.89z";
        private static readonly IconDefinition _definition = new(name: "CrutchIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
