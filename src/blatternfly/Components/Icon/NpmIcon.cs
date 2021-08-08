namespace Blatternfly.Components
{
    public sealed class NpmIcon : BaseIcon
    {
        public static readonly string SvgPath = "M288 288h-32v-64h32v64zm288-128v192H288v32H160v-32H0V160h576zm-416 32H32v128h64v-96h32v96h32V192zm160 0H192v160h64v-32h64V192zm224 0H352v128h64v-96h32v96h32v-96h32v96h32V192z";
        public static readonly IconDefinition IconDefinition = new(name: "NpmIcon", height: 512, width: 576, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
