namespace Blatternfly.Components
{
    public sealed class GitterIcon : BaseIcon
    {
        private static readonly string _svgPath = "M66.4 322.5H16V0h50.4v322.5zM166.9 76.1h-50.4V512h50.4V76.1zm100.6 0h-50.4V512h50.4V76.1zM368 76h-50.4v247H368V76z";
        private static readonly IconDefinition _definition = new(name: "GitterIcon", height: 512, width: 384, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
