namespace Blatternfly.Components
{
    public sealed class PlusCircleIcon : BaseIcon
    {
        private static readonly string _svgPath = "M256 8C119 8 8 119 8 256s111 248 248 248 248-111 248-248S393 8 256 8zm144 276c0 6.6-5.4 12-12 12h-92v92c0 6.6-5.4 12-12 12h-56c-6.6 0-12-5.4-12-12v-92h-92c-6.6 0-12-5.4-12-12v-56c0-6.6 5.4-12 12-12h92v-92c0-6.6 5.4-12 12-12h56c6.6 0 12 5.4 12 12v92h92c6.6 0 12 5.4 12 12v56z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "PlusCircleIcon", height: 512, width: 512, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public PlusCircleIcon() : base(_definition) { }
    }
}