namespace Blatternfly.Components
{
    public sealed class SoapIcon : BaseIcon
    {
        private static readonly string _svgPath = "M416,192a95.42,95.42,0,0,1-30.94,70.21A95.8,95.8,0,0,1,352,448H160a96,96,0,0,1,0-192h88.91A95.3,95.3,0,0,1,224,192H96A96,96,0,0,0,0,288V416a96,96,0,0,0,96,96H416a96,96,0,0,0,96-96V288A96,96,0,0,0,416,192Zm-96,64a64,64,0,1,0-64-64A64,64,0,0,0,320,256ZM208,96a48,48,0,1,0-48-48A48,48,0,0,0,208,96ZM384,64a32,32,0,1,0-32-32A32,32,0,0,0,384,64ZM160,288a64,64,0,0,0,0,128H352a64,64,0,0,0,0-128Z";
        public static readonly IconDefinition IconDefinition = new(name: "SoapIcon", height: 512, width: 512, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}