namespace Blatternfly.Components
{
    public sealed class InfrastructureIcon : BaseIcon
    {
        private static readonly string _svgPath = "M592,64 C618.509668,64 640,85.490332 640,112 L640,112 L640,272 C640,272.7 639.9,273.5 639.9,274.3 L639.9,274.3 L749.6,384 L864,384 C881.673112,384 896,398.326888 896,416 L896,416 L896,544 C896,561.673112 881.673112,576 864,576 L864,576 L832,576 L832,639 L912,639 C938.509668,639 960,660.490332 960,687 L960,687 L960,768 L992,768 C1009.67311,768 1024,782.326888 1024,800 L1024,800 L1024,928 C1024,945.673112 1009.67311,960 992,960 L992,960 L864,960 C846.326888,960 832,945.673112 832,928 L832,928 L832,800 C832,782.326888 846.326888,768 864,768 L864,768 L896,768 L896,703 L704,703 L704,768 L736,768 C753.673112,768 768,782.326888 768,800 L768,800 L768,928 C768,945.673112 753.673112,960 736,960 L736,960 L608,960 C590.326888,960 576,945.673112 576,928 L576,928 L576,800 C576,782.326888 590.326888,768 608,768 L608,768 L640,768 L640,687 C640,660.490332 661.490332,639 688,639 L688,639 L768,639 L768,576 L736,576 C718.326888,576 704,561.673112 704,544 L704,544 L704,428.9 L595,319.9 C594,320 593,320 592,320 L592,320 L430.3,320 L320,430.3 L320,544 C320,561.673112 305.673112,576 288,576 L288,576 L256,576 L256,639 L336,639 C362.509668,639 384,660.490332 384,687 L384,687 L384,768 L416,768 C433.673112,768 448,782.326888 448,800 L448,800 L448,928 C448,945.673112 433.673112,960 416,960 L416,960 L288,960 C270.326888,960 256,945.673112 256,928 L256,928 L256,800 C256,782.326888 270.326888,768 288,768 L288,768 L320,768 L320,703 L128,703 L128,768 L160,768 C177.673112,768 192,782.326888 192,800 L192,800 L192,928 C192,945.673112 177.673112,960 160,960 L160,960 L32,960 C14.326888,960 0,945.673112 0,928 L0,928 L0,800 C0,782.326888 14.326888,768 32,768 L32,768 L64,768 L64,687 C64,660.490332 85.490332,639 112,639 L112,639 L192,639 L192,576 L160,576 C142.326888,576 128,561.673112 128,544 L128,544 L128,416 C128,398.326888 142.326888,384 160,384 L160,384 L275.7,384 L384.1,275.6 C384.1,274.4 384,273.2 384,272 L384,272 L384,112 C384,85.490332 405.490332,64 432,64 L432,64 Z M576,128 L448,128 L448,256 L576,256 L576,128 Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "InfrastructureIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public InfrastructureIcon() : base(_definition) { }
    }
}