namespace Blatternfly.Components
{
    public sealed class MouseIcon : BaseIcon
    {
        private static readonly string _svgPath = "M0 352a160 160 0 0 0 160 160h64a160 160 0 0 0 160-160V224H0zM176 0h-16A160 160 0 0 0 0 160v32h176zm48 0h-16v192h176v-32A160 160 0 0 0 224 0z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "MouseIcon", height: 512, width: 384, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public MouseIcon() : base(_definition) { }
    }
}