namespace Blatternfly.Components
{
    public sealed class FlipboardIcon : BaseIcon
    {
        private static readonly string _svgPath = "M0 32v448h448V32H0zm358.4 179.2h-89.6v89.6h-89.6v89.6H89.6V121.6h268.8v89.6z";
        private static readonly IconDefinition _definition = new(name: "FlipboardIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
