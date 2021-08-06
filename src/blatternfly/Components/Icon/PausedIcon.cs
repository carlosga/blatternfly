namespace Blatternfly.Components
{
    public sealed class PausedIcon : BaseIcon
    {
        private static readonly string _svgPath = "M640,288 C605,288 576,316.7 576,352 L576,672 C576,707.3 604.7,736 640,736 C675.3,736 704,707.3 704,672 L704,352 C704,316.7 675,288 640,288 M384,288 C349,288 320,316.7 320,352 L320,672 C320,707.3 348.7,736 384,736 C419.3,736 448,707.3 448,672 L448,352 C448,316.7 419,288 384,288 M512.1,127.9 C300.3,127.9 128.1,300.2 128.1,511.9 C128.1,723.8 300.3,895.9 512.1,895.9 C723.8,895.9 896.1,723.7 896.1,511.9 C896,300.2 723.8,127.9 512.1,127.9 M512.1,1024 C229.7,1024 0,794.3 0,512 C0,229.7 229.7,0 512.1,0 C794.3,0 1024,229.7 1024,512 C1024,794.3 794.3,1024 512.1,1024";
        private static readonly IconDefinition _definition = new(name: "PausedIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}