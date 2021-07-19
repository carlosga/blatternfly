namespace Blatternfly.Components
{
    public sealed class ProjectDiagramIcon : BaseIcon
    {
        private static readonly string _svgPath = "M384 320H256c-17.67 0-32 14.33-32 32v128c0 17.67 14.33 32 32 32h128c17.67 0 32-14.33 32-32V352c0-17.67-14.33-32-32-32zM192 32c0-17.67-14.33-32-32-32H32C14.33 0 0 14.33 0 32v128c0 17.67 14.33 32 32 32h95.72l73.16 128.04C211.98 300.98 232.4 288 256 288h.28L192 175.51V128h224V64H192V32zM608 0H480c-17.67 0-32 14.33-32 32v128c0 17.67 14.33 32 32 32h128c17.67 0 32-14.33 32-32V32c0-17.67-14.33-32-32-32z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "ProjectDiagramIcon", height: 512, width: 640, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public ProjectDiagramIcon() : base(_definition) { }
    }
}