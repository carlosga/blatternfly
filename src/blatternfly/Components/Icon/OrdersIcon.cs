namespace Blatternfly.Components
{
    public sealed class OrdersIcon : BaseIcon
    {
        public static readonly string SvgPath = "M604.3,361.4 L401.1,564.6 L288.2,451.7 C275.7,439.2 255.5,439.2 243,451.7 L197.8,496.9 C185.3,509.4 185.3,529.6 197.8,542.1 L378.4,722.7 C390.9,735.2 411.1,735.2 423.6,722.7 L694.6,451.7 C707.1,439.2 707.1,419 694.6,406.5 L649.4,361.3 C637,348.9 616.8,348.9 604.3,361.4 L604.3,361.4 Z M384,128 L512,128 L512,64 L384,64 L384,128 Z M576,128 L576,63 C576,27.7 547.3,0 512,0 L386,0 C350.7,0 320,27.7 320,63 L320,128 L192,128 L192,256 L704,256 L704,128 L576,128 Z M768,128 C768.1,128.1 768,895.8 768,895.8 C767.9,895.9 767.8,896 767.8,896 L128,896 L128,128.3 C128.1,128.2 128.1,128.1 128.2,128.1 L0,128 L0,896 C0,966.3 57.6,1024 128,1024 L768,1024 C838.4,1024 896,966.3 896,896 L896,128 L768,128 Z";
        public static readonly IconDefinition IconDefinition = new(name: "OrdersIcon", height: 1024, width: 896, svgPath: SvgPath, transform: null, yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}
