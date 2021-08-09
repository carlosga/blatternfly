namespace Blatternfly.Components
{
    public sealed class OutlinedWindowRestoreIcon : BaseIcon
    {
        private static readonly string _svgPath = "M464 0H144c-26.5 0-48 21.5-48 48v48H48c-26.5 0-48 21.5-48 48v320c0 26.5 21.5 48 48 48h320c26.5 0 48-21.5 48-48v-48h48c26.5 0 48-21.5 48-48V48c0-26.5-21.5-48-48-48zm-96 464H48V256h320v208zm96-96h-48V144c0-26.5-21.5-48-48-48H144V48h320v320z";
        public static readonly IconDefinition IconDefinition = new(name: "OutlinedWindowRestoreIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}