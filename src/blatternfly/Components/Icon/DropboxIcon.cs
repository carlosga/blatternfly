namespace Blatternfly.Components
{
    public sealed class DropboxIcon : BaseIcon
    {
        public static readonly string SvgPath = "M264.4 116.3l-132 84.3 132 84.3-132 84.3L0 284.1l132.3-84.3L0 116.3 132.3 32l132.1 84.3zM131.6 395.7l132-84.3 132 84.3-132 84.3-132-84.3zm132.8-111.6l132-84.3-132-83.6L395.7 32 528 116.3l-132.3 84.3L528 284.8l-132.3 84.3-131.3-85z";
        public static readonly IconDefinition IconDefinition = new(name: "DropboxIcon", height: 512, width: 528, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
