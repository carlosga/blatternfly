namespace Blatternfly.Components
{
    public sealed class CaretDownIcon : BaseIcon
    {
        private static readonly string _svgPath = "M31.3 192h257.3c17.8 0 26.7 21.5 14.1 34.1L174.1 354.8c-7.8 7.8-20.5 7.8-28.3 0L17.2 226.1C4.6 213.5 13.5 192 31.3 192z";
        private static readonly IconDefinition _definition = new(name: "CaretDownIcon", height: 512, width: 320, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}