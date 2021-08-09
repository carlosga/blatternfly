namespace Blatternfly.Components
{
    public sealed class MobileIcon : BaseIcon
    {
        private static readonly string _svgPath = "M272 0H48C21.5 0 0 21.5 0 48v416c0 26.5 21.5 48 48 48h224c26.5 0 48-21.5 48-48V48c0-26.5-21.5-48-48-48zM160 480c-17.7 0-32-14.3-32-32s14.3-32 32-32 32 14.3 32 32-14.3 32-32 32z";
        public static readonly IconDefinition IconDefinition = new(name: "MobileIcon", height: 512, width: 320, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}