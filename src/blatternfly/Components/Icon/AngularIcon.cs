namespace Blatternfly.Components
{
    public sealed class AngularIcon : BaseIcon
    {
        private static readonly string _svgPath = "M185.7 268.1h76.2l-38.1-91.6-38.1 91.6zM223.8 32L16 106.4l31.8 275.7 176 97.9 176-97.9 31.8-275.7zM354 373.8h-48.6l-26.2-65.4H168.6l-26.2 65.4H93.7L223.8 81.5z";
        public static readonly IconDefinition IconDefinition = new(name: "AngularIcon", height: 512, width: 448, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}