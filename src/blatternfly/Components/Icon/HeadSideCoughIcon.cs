namespace Blatternfly.Components
{
    public sealed class HeadSideCoughIcon : BaseIcon
    {
        private static readonly string _svgPath = "M616,304a24,24,0,1,0-24-24A24,24,0,0,0,616,304ZM552,416a24,24,0,1,0,24,24A24,24,0,0,0,552,416Zm-64-56a24,24,0,1,0,24,24A24,24,0,0,0,488,360ZM616,464a24,24,0,1,0,24,24A24,24,0,0,0,616,464Zm0-104a24,24,0,1,0,24,24A24,24,0,0,0,616,360Zm-64-40a24,24,0,1,0,24,24A24,24,0,0,0,552,320Zm-74.78-45c-21-47.12-48.5-151.75-73.12-186.75A208.13,208.13,0,0,0,234.1,0H192C86,0,0,86,0,192c0,56.75,24.75,107.62,64,142.88V512H288V480h64a64,64,0,0,0,64-64H320a32,32,0,0,1,0-64h96V320h32A32,32,0,0,0,477.22,275ZM288,224a32,32,0,1,1,32-32A32.07,32.07,0,0,1,288,224Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "HeadSideCoughIcon", height: 512, width: 640, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public HeadSideCoughIcon() : base(_definition) { }
    }
}