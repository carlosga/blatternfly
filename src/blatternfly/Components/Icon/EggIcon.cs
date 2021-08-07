namespace Blatternfly.Components
{
    public sealed class EggIcon : BaseIcon
    {
        private static readonly string _svgPath = "M192 0C86 0 0 214 0 320s86 192 192 192 192-86 192-192S298 0 192 0z";
        private static readonly IconDefinition _definition = new(name: "EggIcon", height: 512, width: 384, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
