namespace Blatternfly.Components
{
    public sealed class HandScissorsIcon : BaseIcon
    {
        private static readonly string _svgPath = "M216 440c0-22.092 17.909-40 40-40v-8h-32c-22.091 0-40-17.908-40-40s17.909-40 40-40h32v-8H48c-26.51 0-48-21.49-48-48s21.49-48 48-48h208v-13.572l-177.551-69.74c-24.674-9.694-36.818-37.555-27.125-62.228 9.693-24.674 37.554-36.817 62.228-27.124l190.342 74.765 24.872-31.09c12.306-15.381 33.978-19.515 51.081-9.741l112 64A40.002 40.002 0 0 1 512 168v240c0 18.562-12.77 34.686-30.838 38.937l-136 32A39.982 39.982 0 0 1 336 480h-80c-22.091 0-40-17.908-40-40z";
        public static readonly IconDefinition IconDefinition = new(name: "HandScissorsIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}