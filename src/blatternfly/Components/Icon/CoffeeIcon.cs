namespace Blatternfly.Components
{
    public sealed class CoffeeIcon : BaseIcon
    {
        public static readonly string SvgPath = "M192 384h192c53 0 96-43 96-96h32c70.6 0 128-57.4 128-128S582.6 32 512 32H120c-13.3 0-24 10.7-24 24v232c0 53 43 96 96 96zM512 96c35.3 0 64 28.7 64 64s-28.7 64-64 64h-32V96h32zm47.7 384H48.3c-47.6 0-61-64-36-64h583.3c25 0 11.8 64-35.9 64z";
        public static readonly IconDefinition IconDefinition = new(name: "CoffeeIcon", height: 512, width: 640, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
