namespace Blatternfly.Components
{
    public sealed class DiceOneIcon : BaseIcon
    {
        public static readonly string SvgPath = "M384 32H64C28.65 32 0 60.65 0 96v320c0 35.35 28.65 64 64 64h320c35.35 0 64-28.65 64-64V96c0-35.35-28.65-64-64-64zM224 288c-17.67 0-32-14.33-32-32s14.33-32 32-32 32 14.33 32 32-14.33 32-32 32z";
        public static readonly IconDefinition IconDefinition = new(name: "DiceOneIcon", height: 512, width: 448, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
