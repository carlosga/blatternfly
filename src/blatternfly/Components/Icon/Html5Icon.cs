namespace Blatternfly.Components
{
    public sealed class Html5Icon : BaseIcon
    {
        private static readonly string _svgPath = "M0 32l34.9 395.8L191.5 480l157.6-52.2L384 32H0zm308.2 127.9H124.4l4.1 49.4h175.6l-13.6 148.4-97.9 27v.3h-1.1l-98.7-27.3-6-75.8h47.7L138 320l53.5 14.5 53.7-14.5 6-62.2H84.3L71.5 112.2h241.1l-4.4 47.7z";
        public static readonly IconDefinition IconDefinition = new(name: "Html5Icon", height: 512, width: 384, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}