namespace Blatternfly.Components
{
    public sealed class PrescriptionBottleIcon : BaseIcon
    {
        private static readonly string _svgPath = "M32 192h120c4.4 0 8 3.6 8 8v16c0 4.4-3.6 8-8 8H32v64h120c4.4 0 8 3.6 8 8v16c0 4.4-3.6 8-8 8H32v64h120c4.4 0 8 3.6 8 8v16c0 4.4-3.6 8-8 8H32v64c0 17.6 14.4 32 32 32h256c17.6 0 32-14.4 32-32V128H32v64zM360 0H24C10.8 0 0 10.8 0 24v48c0 13.2 10.8 24 24 24h336c13.2 0 24-10.8 24-24V24c0-13.2-10.8-24-24-24z";
        private static readonly IconDefinition _definition = new(name: "PrescriptionBottleIcon", height: 512, width: 384, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}