namespace Blatternfly.Components
{
    public sealed class MdbIcon : BaseIcon
    {
        private static readonly string _svgPath = "M17.37 160.41L7 352h43.91l5.59-79.83L84.43 352h44.71l25.54-77.43 4.79 77.43H205l-12.79-191.59H146.7L106 277.74 63.67 160.41zm281 0h-47.9V352h47.9s95 .8 94.2-95.79c-.78-94.21-94.18-95.78-94.18-95.78zm-1.2 146.46V204.78s46 4.27 46.8 50.57-46.78 51.54-46.78 51.54zm238.29-74.24a56.16 56.16 0 0 0 8-38.31c-5.34-35.76-55.08-34.32-55.08-34.32h-51.9v191.58H482s87 4.79 87-63.85c0-43.14-33.52-55.08-33.52-55.08zm-51.9-31.94s13.57-1.59 16 9.59c1.43 6.66-4 12-4 12h-12v-21.57zm-.1 109.46l.1-24.92V267h.08s41.58-4.73 41.19 22.43c-.33 25.65-41.35 20.74-41.35 20.74z";
        private static readonly IconDefinition _definition = new(name: "MdbIcon", height: 512, width: 576, svgPath: _svgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}
