namespace Blatternfly.Components
{
    public sealed class PumpSoapIcon : BaseIcon
    {
        private static readonly string _svgPath = "M235.63,160H84.37a64,64,0,0,0-63.74,58.21L.27,442.21A64,64,0,0,0,64,512H256a64,64,0,0,0,63.74-69.79l-20.36-224A64,64,0,0,0,235.63,160ZM160,416c-33.12,0-60-26.33-60-58.75,0-25,35.7-75.47,52-97.27A10,10,0,0,1,168,260c16.33,21.8,52,72.27,52,97.27C220,389.67,193.12,416,160,416ZM379.31,94.06,336,50.74A64,64,0,0,0,290.75,32H224A32,32,0,0,0,192,0H128A32,32,0,0,0,96,32v96H224V96h66.75l43.31,43.31a16,16,0,0,0,22.63,0l22.62-22.62A16,16,0,0,0,379.31,94.06Z";
        public static readonly IconDefinition IconDefinition = new(name: "PumpSoapIcon", height: 512, width: 384, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}