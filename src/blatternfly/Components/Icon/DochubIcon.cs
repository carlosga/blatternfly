namespace Blatternfly.Components
{
    public sealed class DochubIcon : BaseIcon
    {
        private static readonly string _svgPath = "M397.9 160H256V19.6L397.9 160zM304 192v130c0 66.8-36.5 100.1-113.3 100.1H96V84.8h94.7c12 0 23.1.8 33.1 2.5v-84C212.9 1.1 201.4 0 189.2 0H0v512h189.2C329.7 512 400 447.4 400 318.1V192h-96z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "DochubIcon", height: 512, width: 416, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public DochubIcon() : base(_definition) { }
    }
}