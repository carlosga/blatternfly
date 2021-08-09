namespace Blatternfly.Components
{
    public sealed class ArchwayIcon : BaseIcon
    {
        private static readonly string _svgPath = "M560 448h-16V96H32v352H16.02c-8.84 0-16 7.16-16 16v32c0 8.84 7.16 16 16 16H176c8.84 0 16-7.16 16-16V320c0-53.02 42.98-96 96-96s96 42.98 96 96l.02 160v16c0 8.84 7.16 16 16 16H560c8.84 0 16-7.16 16-16v-32c0-8.84-7.16-16-16-16zm0-448H16C7.16 0 0 7.16 0 16v32c0 8.84 7.16 16 16 16h544c8.84 0 16-7.16 16-16V16c0-8.84-7.16-16-16-16z";
        public static readonly IconDefinition IconDefinition = new(name: "ArchwayIcon", height: 512, width: 576, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}