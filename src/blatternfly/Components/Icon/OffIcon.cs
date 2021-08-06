namespace Blatternfly.Components
{
    public sealed class OffIcon : BaseIcon
    {
        private static readonly string _svgPath = "M512,288 C476.710699,288.137047 448.137047,316.710699 448,352 L448,672 C448,707.346224 476.653776,736 512,736 C547.346224,736 576,707.346224 576,672 L576,352 C575.862953,316.710699 547.289301,288.137047 512,288 M512,896 C299.9,896 128,724.1 128,512 C128,299.9 299.9,128 512,128 C724.1,128 896,299.9 896,512 C896,724.1 724.1,896 512,896 M512,0 C229.2,0 0,229.2 0,512 C0,794.8 229.2,1024 512,1024 C794.8,1024 1024,794.8 1024,512 C1024,229.2 794.8,0 512,0";
        private static readonly IconDefinition _definition = new(name: "OffIcon", height: 1024, width: 1024, svgPath: _svgPath, transform: "", yOffset: "", xOffset: "");

        protected override IconDefinition Definition { get => _definition; }
    }
}