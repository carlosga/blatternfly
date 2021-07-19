namespace Blatternfly.Components
{
    public sealed class VolumeOffIcon : BaseIcon
    {
        private static readonly string _svgPath = "M215 71l-89 89H24a24 24 0 0 0-24 24v144a24 24 0 0 0 24 24h102.06L215 441c15 15 41 4.47 41-17V88c0-21.47-26-32-41-17z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "VolumeOffIcon", height: 512, width: 256, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public VolumeOffIcon() : base(_definition) { }
    }
}