namespace Blatternfly.Components
{
    public sealed class NewProcessIcon : BaseIcon
    {
        private static readonly string _svgPath = "M512.096,-0.032 C794.336,-0.032 1024.032,229.728 1024.032,511.968 C1024.032,794.336 794.336,1023.968 512.096,1023.968 C229.664,1023.968 0.032,794.336 0.032,511.968 C0.032,229.728 229.664,-0.032 512.096,-0.032 Z M512.096,127.904 C300.32,127.904 128.096,300.192 128.096,511.904 C128.096,723.808 300.32,895.904 512.096,895.904 C723.808,895.904 896.096,723.744 896.096,511.904 C896.032,300.192 723.808,127.904 512.096,127.904 Z M688,256 C696.832,256 704,263.232 704,272 L704,272 L704,288 C704,448 544,447.04 544,512 C544,577.024 704,576 704,736 L704,736 L704,752 C704,760.832 696.832,768 688,768 L688,768 L336,768 C327.168,768 320,760.832 320,752 L320,752 L320,736 C320,575.04 480,575.04 480,512 C480,449.024 320,447.04 320,288 L320,288 L320,272 C320,263.232 327.168,256 336,256 L336,256 Z M528.896,612.352 C512.32,606.656 512.32,606.656 495.232,612.352 C480.128,617.408 426.816,634.56 419.392,686.784 C419.375111,686.898667 419.358272,687.013469 419.341491,687.128382 L419.241602,687.818968 L419.241602,687.818968 L419.143614,688.510949 C419.079028,688.972458 419.016028,689.434069 418.95525,689.894125 L418.86583,690.582835 C417.975284,697.568642 417.675556,704 420.224,704 L420.224,704 L603.84,704 C606.381972,704 606.09022,697.738385 605.243569,690.854278 L605.157138,690.164001 L605.157138,690.164001 L605.067515,689.470828 L605.067515,689.470828 L604.975205,688.776011 C604.944043,688.54427 604.912519,688.312465 604.880715,688.080803 L604.736,687.04 C597.568,635.456 544,617.664 528.896,612.352 Z M603.84,317.344 L420.288,317.344 C417.661296,317.344 418.108897,324.078816 418.989313,331.241174 L419.075776,331.935429 C419.090383,332.051289 419.10508,332.167209 419.119856,332.28316 L419.209375,332.979036 C419.269572,333.442926 419.330683,333.906479 419.392,334.368 C426.56,385.952 480.128,403.744 495.232,409.056 C511.493818,414.622545 511.863405,414.749058 527.820992,409.435537 L528.96,409.056 C544.064,403.936 597.376,386.848 604.8,334.56 C604.817127,334.44462 604.834177,334.329074 604.851142,334.213392 L605.001247,333.169277 L605.001247,333.169277 L605.145152,332.122198 C606.14273,324.676336 606.551437,317.344 603.84,317.344 L603.84,317.344 Z";
        private static readonly IconDefinition _definition = new IconDefinition(name: "NewProcessIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        public NewProcessIcon() : base(_definition) { }
    }
}