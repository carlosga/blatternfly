namespace Blatternfly.Components
{
    public sealed class MicrosoftIcon : BaseIcon
    {
        public static readonly string SvgPath = "M0 32h214.6v214.6H0V32zm233.4 0H448v214.6H233.4V32zM0 265.4h214.6V480H0V265.4zm233.4 0H448V480H233.4V265.4z";
        public static readonly IconDefinition IconDefinition = new(name: "MicrosoftIcon", height: 512, width: 448, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
