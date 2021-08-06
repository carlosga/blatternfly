namespace Blatternfly.Components
{
    public sealed class GenderlessIcon : BaseIcon
    {
        private static readonly string _svgPath = "M144 176c44.1 0 80 35.9 80 80s-35.9 80-80 80-80-35.9-80-80 35.9-80 80-80m0-64C64.5 112 0 176.5 0 256s64.5 144 144 144 144-64.5 144-144-64.5-144-144-144z";
        private static readonly IconDefinition _definition = new(name: "GenderlessIcon", height: 512, width: 288, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}