namespace Blatternfly.Components
{
    public sealed class UnsplashIcon : BaseIcon
    {
        public static readonly string SvgPath = "M448,230.17V480H0V230.17H141.13V355.09H306.87V230.17ZM306.87,32H141.13V156.91H306.87Z";
        public static readonly IconDefinition IconDefinition = new(name: "UnsplashIcon", height: 512, width: 448, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
