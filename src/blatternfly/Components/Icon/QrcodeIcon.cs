namespace Blatternfly.Components
{
    public sealed class QrcodeIcon : BaseIcon
    {
        private static readonly string _svgPath = "M0 224h192V32H0v192zM64 96h64v64H64V96zm192-64v192h192V32H256zm128 128h-64V96h64v64zM0 480h192V288H0v192zm64-128h64v64H64v-64zm352-64h32v128h-96v-32h-32v96h-64V288h96v32h64v-32zm0 160h32v32h-32v-32zm-64 0h32v32h-32v-32z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "QrcodeIcon", height: 512, width: 448, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public QrcodeIcon() : base(_definition) { }
    }
}