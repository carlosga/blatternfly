namespace Blatternfly.Components
{
    public sealed class NpmIcon : BaseIcon
    {
        private static readonly string _svgPath = "M288 288h-32v-64h32v64zm288-128v192H288v32H160v-32H0V160h576zm-416 32H32v128h64v-96h32v96h32V192zm160 0H192v160h64v-32h64V192zm224 0H352v128h64v-96h32v96h32v-96h32v96h32V192z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "NpmIcon", height: 512, width: 576, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public NpmIcon() : base(_definition) { }
    }
}