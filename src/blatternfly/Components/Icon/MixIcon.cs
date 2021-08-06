namespace Blatternfly.Components
{
    public sealed class MixIcon : BaseIcon
    {
        private static readonly string _svgPath = "M0 64v348.9c0 56.2 88 58.1 88 0V174.3c7.9-52.9 88-50.4 88 6.5v175.3c0 57.9 96 58 96 0V240c5.3-54.7 88-52.5 88 4.3v23.8c0 59.9 88 56.6 88 0V64H0z";
        private static readonly IconDefinition _definition = new(name: "MixIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}