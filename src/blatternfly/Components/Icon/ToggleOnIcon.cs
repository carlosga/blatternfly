namespace Blatternfly.Components
{
    public sealed class ToggleOnIcon : BaseIcon
    {
        private static readonly string _svgPath = "M384 64H192C86 64 0 150 0 256s86 192 192 192h192c106 0 192-86 192-192S490 64 384 64zm0 320c-70.8 0-128-57.3-128-128 0-70.8 57.3-128 128-128 70.8 0 128 57.3 128 128 0 70.8-57.3 128-128 128z";
        private static readonly IconDefinition _definition = new(name: "ToggleOnIcon", height: 512, width: 576, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}