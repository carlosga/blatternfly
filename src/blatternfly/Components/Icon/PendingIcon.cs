namespace Blatternfly.Components
{
    public sealed class PendingIcon : BaseIcon
    {
        private static readonly string _svgPath = "M512.1,895.9 C300.3,895.9 128.1,723.8 128.1,511.9 C128.1,300.2 300.3,127.9 512.1,127.9 C723.8,127.9 896,300.2 896.1,511.9 C896.1,723.7 723.8,895.9 512.1,895.9 M512.1,0 C229.7,0 0,229.7 0,512 C0,794.3 229.7,1024 512.1,1024 C794.3,1024 1024,794.3 1024,512 C1024,229.7 794.3,0 512.1,0 M704,288 L704,272 C704,263.2 696.8,256 688,256 L336,256 C327.2,256 320,263.2 320,272 L320,288 C320,447 480,449 480,512 C480,575 320,575 320,736 L320,752 C320,760.8 327.2,768 336,768 L688,768 C696.8,768 704,760.8 704,752 L704,736 C704,576 544,577 544,512 C544,447 704,448 704,288 M603.9,704 L420.3,704 C417.3,704 418.2,695 419.4,686.8 C426.8,634.5 480.1,617.4 495.2,612.3 C512.3,606.6 512.3,606.6 528.9,612.3 C544,617.6 597.6,635.4 604.8,687 C605.9,695.2 606.9,704 603.9,704";
        public static readonly IconDefinition IconDefinition = new(name: "PendingIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: null, offsetY: "", offsetX: "");

        protected override IconDefinition Definition { get => IconDefinition; }
    }
}